using MongoDB.Driver;
using MongoDB.Bson;
using SharedLibrary;
using MongoDB.Driver.Linq;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<User> _users;
    public IMongoQueryable<User> Users => _users.AsQueryable();

    public MongoDBContext(string connectionString, string databaseName)
    {
        MongoClient client = new(connectionString);
        _database = client.GetDatabase(databaseName);
        _users = _database.GetCollection<User>("Users");
    }

    public async Task AddUserAsync(User user)
    {
        user.Id = Guid.NewGuid().ToString();
        await _users.InsertOneAsync(user);
    }

    public async Task<bool> RemoveUserAsync(User user)
    {
        FilterDefinition<User> filter = Builders<User>.Filter.Eq(u => u.Username, user.Username);
        var result = await _users.DeleteOneAsync(filter);
        return result.DeletedCount == 1;
    }
}