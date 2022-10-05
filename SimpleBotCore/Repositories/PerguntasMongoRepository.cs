using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using SimpleBotCore.Model;
using SimpleBotCore.Repositories.Mongo;

namespace SimpleBotCore.Repositories;
public class PerguntasMongoRepository : BaseRepositoryMongo<BotPergunta>, IPerguntasRepository
{

    public string Name { get; private set; }
    public PerguntasMongoRepository(IMongoDbContext context) : base(context)
    {
        Name = nameof(PerguntasMongoRepository);
    }
}
