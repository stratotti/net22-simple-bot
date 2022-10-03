using MongoDB.Bson;
using SimpleBotCore.Repositories.Mongo;

namespace SimpleBotCore.Repositories;
public interface IPerguntasMongoRepository : IBaseRepositoryMongo<BsonDocument>
{
}
