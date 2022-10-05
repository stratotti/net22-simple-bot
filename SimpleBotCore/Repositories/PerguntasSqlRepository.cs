using SimpleBotCore.Model;
using SimpleBotCore.Repositories.Sql;
using System.Threading.Tasks;

namespace SimpleBotCore.Repositories;
public class PerguntasSqlRepository : BaseRepositorySql<BotPergunta>, IPerguntasRepository
{
    public string Name { get; private set; }
    public PerguntasSqlRepository(ISqlDbContext context) : base(context)
	{
		Name = nameof(PerguntasSqlRepository);
	}

	public override async Task InsertAsync(BotPergunta entity)
	{
		var query = "insert into Perguntas values (@Pergunta)";
		await ExecuteAsync(query, new { @Pergunta = entity.Pergunta });
	}
}
