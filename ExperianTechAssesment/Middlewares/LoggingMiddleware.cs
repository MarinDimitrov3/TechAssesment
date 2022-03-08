using ExperianTechAssesment.Data.Interfaces;
using Microsoft.IO;
using Newtonsoft.Json;
using System.Dynamic;

namespace ExperianTechAssesment.Middlewares
{
    public class LoggingMiddleware : IMiddleware    {
        private readonly ILogRequestResponse _log;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        public LoggingMiddleware(ILogRequestResponse log)
        {
            _log = log;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var request = await LogRequest(context);
            var response = await LogResponse(context, next);
            await _log.LogRequestResponseInDb(request, response);
        }

        private async Task<ExpandoObject> LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();
            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);
            dynamic request = new ExpandoObject();
            request.Scheme = context.Request.Scheme;
            request.Host = context.Request.Host.Value;
            request.Path = context.Request.Path.Value;
            request.RequestBody = JsonConvert.DeserializeObject<ExpandoObject>(ReadStreamInChunks(requestStream));
            context.Request.Body.Position = 0;
            return request;
        }

        private async Task<ExpandoObject> LogResponse(HttpContext context, RequestDelegate next)
        {
            var originalBodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;
            await next(context);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            dynamic response = new ExpandoObject();
            response.ResponseBody = JsonConvert.DeserializeObject<ExpandoObject>(text);
            await responseBody.CopyToAsync(originalBodyStream);
            return response;
        }
        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            stream.Seek(0, SeekOrigin.Begin);
            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;
            do
            {
                readChunkLength = reader.ReadBlock(readChunk, 0, readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);
            return textWriter.ToString();
        }
    }
}
