using ExperianTechAssesment.Data.Helpers;
using ExperianTechAssesment.Data.Interfaces;
using MongoDB.Driver;

namespace ExperianTechAssesment.Extensions
{
    public static class RegisterMongoDbRepositoriesExtension
    {
        public static void RegisterMongoDbRepositories(this IServiceCollection servicesBuilder)
        {
            servicesBuilder.AddSingleton<IMongoClient, MongoClient>(s =>
            {
                var uri = s.GetRequiredService<IConfiguration>()["MongoDbConnectionString"];
                return new MongoClient(uri);
            });
            servicesBuilder.AddSingleton<ILogRequestResponse, LogRequestResponseMongo>();
        }
    }
}
