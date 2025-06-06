namespace GatewayManager.Api.Models;

public class OpenIdConnectPlugin
{
	public string ClientId { get; set; }
	public string ClientSecret { get; set; }
	public string Discovery { get; set; }
	public string Realm { get; set; }
	public string IntrospectionEndpointAuthMethod { get; set; }
}
