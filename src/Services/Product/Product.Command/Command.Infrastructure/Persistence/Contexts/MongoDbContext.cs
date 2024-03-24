using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Data;

namespace Command.Infrastructure.Persistence.Contexts;

public class MongoDbContext
{
    private readonly IConfiguration _configuration;

    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }
}
