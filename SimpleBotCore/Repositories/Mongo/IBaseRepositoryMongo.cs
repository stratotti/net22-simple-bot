using System.Threading.Tasks;

namespace SimpleBotCore.Repositories.Mongo;
public interface IBaseRepositoryMongo<TEntity>
{
    Task InsertAsync(TEntity entity);
}
