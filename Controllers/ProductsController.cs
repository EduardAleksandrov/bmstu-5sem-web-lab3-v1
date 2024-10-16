using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DBase.Models;
using DBase.Data;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("id", Name = "GetWeatherForecast")]
    // [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpGet("products", Name = "GetProducts")]
    public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }
}
