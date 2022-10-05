using Microsoft.Extensions.Options;
using SimpleBotCore.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SimpleBotCore.Repositories.Sql;
public class SqlDbContext : ISqlDbContext
{
    private readonly string _connectionString;

    public SqlDbContext(IOptions<ConnectionStrings> connectionString) =>
        _connectionString = connectionString.Value.DbConnectionSql;
    public IDbConnection GetConnection()
    {
        var facory = SqlClientFactory.Instance;
        var connection = facory.CreateConnection();
        connection.ConnectionString = _connectionString;
        return connection;
    }
}
