using MongoDB.Bson;
using SimpleBotCore.Repositories.Mongo;

namespace SimpleBotCore.Repositories;
public class PerguntasMongoRepository : BaseRepositoryMongo<BsonDocument>, IPerguntasMongoRepository
{
    public PerguntasMongoRepository(IMongoDbContext context) : base(context)
    {

    }
}
