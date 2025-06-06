namespace GatewayManager.Api.Models;

public class ApisixRoute
{
	public string Uri { get; set; }
	public ApisixPlugins Plugins { get; set; }
	public ApisixUpstream Upstream { get; set; }
}
