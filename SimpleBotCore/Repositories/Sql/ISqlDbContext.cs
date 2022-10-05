using System.Data;

namespace SimpleBotCore.Repositories.Sql;
public interface ISqlDbContext
{
    IDbConnection GetConnection();
}
