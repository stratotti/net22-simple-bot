using SimpleBotCore.Model;

namespace SimpleBotCore.Repositories;
public interface IPerguntasRepository : IBaseRepository<BotPergunta>
{
    public string Name { get; }
}
