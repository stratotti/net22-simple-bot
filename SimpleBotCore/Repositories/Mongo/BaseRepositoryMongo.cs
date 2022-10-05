using MongoDB.Driver;
using System.Threading.Tasks;

namespace SimpleBotCore.Repositories.Mongo;
public abstract class BaseRepositoryMongo<TEntity> : IBaseRepository<TEntity>
{
    public readonly IMongoCollection<TEntity> _collection;

    protected BaseRepositoryMongo(IMongoDbContext context) =>
            _collection = context.GetCollection<TEntity>();
    public async virtual Task InsertAsync(TEntity entity) =>
        await _collection.InsertOneAsync(entity);
}
