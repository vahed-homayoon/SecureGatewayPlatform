namespace GatewayManager.Api.Models;

public class ApisixPlugins
{
	public OpenIdConnectPlugin OpenidConnect { get; set; }
	public ProxyRewritePlugin ProxyRewrite { get; set; }
}
