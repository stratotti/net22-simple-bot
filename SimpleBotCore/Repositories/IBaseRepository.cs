using System.Threading.Tasks;

namespace SimpleBotCore.Repositories;
public interface IBaseRepository<TEntity>
{
    Task InsertAsync(TEntity entity);
}
