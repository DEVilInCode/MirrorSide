using MongoDB.Driver;
using MongoDB.Bson;
using SharedLibrary;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;
    public IMongoCollection<User> Users { get; }

    public MongoDBContext(string connectionString, string databaseName)
    {
        MongoClient client = new(connectionString);
        _database = client.GetDatabase(databaseName);
        Users = _database.GetCollection<User>("Users");
    }

    public void AddUser(User user)
    {
        user.Id = Guid.NewGuid().ToString();
        Users.InsertOne(user);
    }
}