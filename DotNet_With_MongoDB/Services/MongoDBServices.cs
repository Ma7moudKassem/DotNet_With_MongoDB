using MongoDB.Driver;

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

    public async Task<List<Employee>> GetAsync() =>
        await _employeeCollection.Find(new BsonDocument()).ToListAsync();
    public async Task AddAsync(Employee employee) =>
         await _employeeCollection.InsertOneAsync(employee);
    //public async Task UpdateAsync(Employee employee)=> await _employeeCollection.FindOneAndUpdate(employee.Id , employee);

    //public Task DeleteAsync(string id)
    //{
    //    throw new NotImplementedException();
    //}
}
