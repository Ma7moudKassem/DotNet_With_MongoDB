namespace DotNet_With_MongoDB;

public class MongoDBServices
{
    private readonly IMongoCollection<Employee> _employeeCollection;
    public MongoDBServices(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _employeeCollection = database.GetCollection<Employee>(mongoDBSettings.Value.CollectionName);
    }


}
