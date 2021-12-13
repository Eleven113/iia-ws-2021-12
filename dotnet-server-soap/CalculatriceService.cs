

public class CalculatriceService : ICalculatriceService
{
	public CalculatriceResult Additionner(int a, int b)
	{
		return new CalculatriceResult(a + b);
	}

	public CalculatriceResult Soustraire(int a, int b)
	{
		return new CalculatriceResult(a - b);
	}
}