
using System.Runtime.Serialization;

[DataContract]
public class CalculatriceResult
{
	[DataMember]
	public int Value { get; set; }

	public CalculatriceResult()
	{
		
	}

	public CalculatriceResult(int value) {
		this.Value = value;
	}
}