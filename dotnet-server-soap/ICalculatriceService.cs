
using System.ServiceModel;

[ServiceContract]
public interface ICalculatriceService
{
	[OperationContract]
	public CalculatriceResult Additionner(int a, int b);
	[OperationContract]
	public CalculatriceResult Soustraire(int a, int b);
}