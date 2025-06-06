using GatewayManager.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace GatewayManager.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : ControllerBase
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;

		public TokenController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		[HttpPost]
		public async Task<IActionResult> GetToken([FromBody] TokenRequest request)
		{
			var keycloakUrl = _configuration["Keycloak:Url"]?.TrimEnd('/');

			if (string.IsNullOrEmpty(keycloakUrl))
				return BadRequest("Keycloak URL is not configured");

			var ssss = _configuration["Keycloak:PrAddress:RealmName"];

			string tokenEndpoint = $"{keycloakUrl}/realms/{_configuration["Keycloak:PrAddress:RealmName"] ?? ""}/protocol/openid-connect/token";

			var client = _httpClientFactory.CreateClient();

			var parameters = new List<KeyValuePair<string, string>>
			{
				new("grant_type", _configuration["Keycloak:PrAddress:GrantType"]??""),
				new("client_id", _configuration["Keycloak:PrAddress:ClientId"]??""),
				new("client_secret", _configuration["Keycloak:PrAddress:ClientSecret"]??""),
				new("username", request.Username),
				new("password", request.Password)
			};

			var content = new FormUrlEncodedContent(parameters);

			var response = await client.PostAsync(tokenEndpoint, content);

			var responseBody = await response.Content.ReadAsStringAsync();

			if (response.IsSuccessStatusCode)
				return Content(responseBody, "application/json");

			return StatusCode((int)response.StatusCode, responseBody);
		}
	}
}
