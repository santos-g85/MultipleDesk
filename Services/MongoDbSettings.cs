namespace MultipleDesk.Services
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;

        public string RegistratrationCollectionName { get; set; } = "Registration";
    }
}
