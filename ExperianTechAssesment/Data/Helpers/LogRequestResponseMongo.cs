using ExperianTechAssesment.Data.Constants;
using ExperianTechAssesment.Data.Interfaces;
using ExperianTechAssesment.Data.Models;
using MongoDB.Driver;
using System.Dynamic;

namespace ExperianTechAssesment.Data.Helpers
{
    public class LogRequestResponseMongo : ILogRequestResponse
    {
        private IMongoClient _mongoClient;
        private IMongoCollection<LogModel> _mongoCollection;
        public LogRequestResponseMongo(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            IMongoDatabase db = _mongoClient.GetDatabase(DatabaseNames.ExperianTechAssesment);
            _mongoCollection = db.GetCollection<LogModel>(CollectionNames.GetCreditCardOffersLogs);
        }

        public async Task<bool> LogRequestResponseInDb(ExpandoObject request, ExpandoObject response)
        {
            var model = new LogModel() { Request = request, Response = response, DateOfLog = DateTime.UtcNow};
            try
            {
                await _mongoCollection.InsertOneAsync(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
