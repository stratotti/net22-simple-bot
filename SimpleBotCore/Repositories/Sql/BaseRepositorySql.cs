using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace SimpleBotCore.Repositories.Sql;
public abstract class BaseRepositorySql<TEntity> : IBaseRepository<TEntity>
{
    private readonly ISqlDbContext _dbContext;

    public BaseRepositorySql(ISqlDbContext dbContext) =>
        _dbContext = dbContext;
    public abstract Task InsertAsync(TEntity entity);

    protected async Task<int> ExecuteAsync(string query, object param = null)
    {
        using (IDbConnection con = _dbContext.GetConnection())
            return await con.ExecuteAsync(query, param);
    }
}
