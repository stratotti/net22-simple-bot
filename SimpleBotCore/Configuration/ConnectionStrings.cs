namespace SimpleBotCore.Configuration;
public record ConnectionStrings
{
    public string DbConnection { get; init; }
    public string DataBase { get; init; }
    public string Collection { get; init; }

}
