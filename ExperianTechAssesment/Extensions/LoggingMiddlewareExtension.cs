using ExperianTechAssesment.Middlewares;

namespace ExperianTechAssesment.Extensions
{
    public static class LoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
