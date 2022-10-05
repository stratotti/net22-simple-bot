namespace SimpleBotCore.Configuration;
public record ConnectionStrings
{
    public string DbConnectionMongo { get; init; }
    public string DbConnectionSql { get; init; }
    public string DataBase { get; init; }
    public string Collection { get; init; }
    
}
