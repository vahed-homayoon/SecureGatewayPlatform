namespace GatewayManager.Api.Models;

public class ApisixUpstream
{
	public string Type { get; set; }
	public Dictionary<string, int> Nodes { get; set; }
}
