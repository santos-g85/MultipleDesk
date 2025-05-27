using MongoDB.Driver;
using MultipleDesk.Models;

namespace MultipleDesktop.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<UserRegistration> _registrations;

        public MongoDbService(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("MongoDb");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "MongoDb connection string is missing.");

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("MultipleDesktopDb");
            _registrations = database.GetCollection<UserRegistration>("Registrations");
        }

        public void Register(UserRegistration registration)
        {
            _registrations.InsertOne(registration);
        }
    }
}