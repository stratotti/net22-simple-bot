using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SimpleBotCore.Configuration;
using System.Security.Authentication;

namespace SimpleBotCore.Repositories.Mongo;
public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _mongoDatabase;

    public MongoDbContext(IOptions<ConnectionStrings> connectionStrings )
    {
        MongoClientSettings settings = MongoClientSettings.FromUrl(
          new MongoUrl(connectionStrings.Value.DbConnection));

        settings.SslSettings =
          new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
        MongoClient mongoClient = new(settings);

        this._mongoDatabase = mongoClient.GetDatabase(connectionStrings.Value.DataBase);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return this._mongoDatabase.GetCollection<T>(collectionName);
    }
}
