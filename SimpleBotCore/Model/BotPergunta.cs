namespace SimpleBotCore.Model;
public record BotPergunta
{
    public string Pergunta { get; init; }

	public BotPergunta(string botPergunta)
	{
        Pergunta = botPergunta;
    }
}