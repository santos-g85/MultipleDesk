//using Microsoft.Extensions.Options;
//using MongoDB.Driver;
//using MultipleDesk.Models;
//using MultipleDesk.Services;

//namespace MultipleDesktop.Services
//{
//    public class MongoDbService
//    {
//        private readonly IMongoCollection<UserRegistration> _registrations;

//        public MongoDbService(IConfiguration config)
//        {
//            var connectionString = config.GetConnectionString("MongoDb");

//            if (string.IsNullOrWhiteSpace(connectionString))
//                throw new ArgumentNullException(nameof(connectionString), "MongoDb connection string is missing.");

//            var client = new MongoClient(connectionString);
//            var database = client.GetDatabase("MultipleDesktopDb");
//            _registrations = database.GetCollection<UserRegistration>("Registrations");
//        }

//        public void Register(UserRegistration registration)
//        {
//            _registrations.InsertOne(registration);
//        }
//    }
//}


//using Microsoft.Extensions.Options;
//using MongoDB.Driver;
//using MongoDB.Driver.Core.Configuration;
//using MultipleDesk.Models;
//using MultipleDesk.Services;

//namespace MultipleDesktop.Services
//{
//    public class MongoDbService
//    {
//        private readonly IMongoCollection<UserRegistration> _registrations;

//        public MongoDbService(IOptions<MongoDbSettings> settings)
//        {
//            var client = new MongoClient(settings.Value.ConnectionString);

//            if (string.IsNullOrWhiteSpace(client))
//                throw new ArgumentNullException(nameof(client), "MongoDb connection string is missing.");

//                var database = client.GetDatabase(settings.Value.DatabaseName);
//            _registrations = database.GetCollection<UserRegistration>("Registrations");
//        }

//        public void Register(UserRegistration registration)
//        {
//            _registrations.InsertOne(registration);
//        }
//    }
//}


using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MultipleDesk.Models;
using MultipleDesk.Services;

namespace MultipleDesktop.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<UserRegistration> _registrations;

        public MongoDbService(IOptions<MongoDbSettings> settings)
        {
            var mongoSettings = settings.Value;

            if (string.IsNullOrWhiteSpace(mongoSettings.ConnectionString))
                throw new ArgumentNullException(nameof(mongoSettings.ConnectionString), "MongoDB connection string is missing.");

            var client = new MongoClient(mongoSettings.ConnectionString);
            var database = client.GetDatabase(mongoSettings.DatabaseName);
            _registrations = database.GetCollection<UserRegistration>(mongoSettings.RegistratrationCollectionName);
        }

        public void Register(UserRegistration registration)
        {
            _registrations.InsertOne(registration);
        }
    }
}