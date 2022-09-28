using MongoDB.Driver;

namespace SimpleBotCore.Repositories.Mongo;
public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>(string collectionName);
}
