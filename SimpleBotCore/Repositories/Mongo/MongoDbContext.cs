using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SimpleBotCore.Configuration;
using System.Security.Authentication;

namespace SimpleBotCore.Repositories.Mongo;
public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _mongoDatabase;
    private readonly string _collectionName;

    public MongoDbContext(IOptions<ConnectionStrings> connectionStrings )
    {
        MongoClientSettings settings = MongoClientSettings.FromUrl(
          new MongoUrl(connectionStrings.Value.DbConnectionMongo));

        settings.SslSettings =
          new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
        MongoClient mongoClient = new(settings);

        _mongoDatabase = mongoClient.GetDatabase(connectionStrings.Value.DataBase);
        _collectionName = connectionStrings.Value.Collection;
    }

    public IMongoCollection<T> GetCollection<T>()
    {
        return this._mongoDatabase.GetCollection<T>(_collectionName);
    }
}
