using Microsoft.AspNetCore.Mvc;
using PrAddress.Api.Models;

namespace PrAddress.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
	[HttpGet]
	public IEnumerable<ProductModel> Get()
	{
		return [.. Enumerable.Range(1, 5)
			.Select(index => new
					ProductModel(index + 1, $"Product {index + 1}", Random.Shared.Next(150000, 450000))
		)];
	}
}
