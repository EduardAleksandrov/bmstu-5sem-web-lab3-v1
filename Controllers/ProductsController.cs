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
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(Order orderCreateDto)
    {
        // Validate the incoming DTO
        if (orderCreateDto == null || orderCreateDto.OrderDetails == null || !orderCreateDto.OrderDetails.Any())
        {
            return BadRequest("Order details cannot be null or empty.");
        }

        // Create a new Order object
        Guid id_o = Guid.NewGuid();
        var order = new Order
        {
            ID_Order = id_o,
            CustomerID = orderCreateDto.CustomerID,
            OrderDate = DateTime.UtcNow, // Set the order date to UTC
            Status = "Pending" // Set initial status
        };

        // Calculate TotalAmount based on OrderDetails
        order.TotalAmount = orderCreateDto.OrderDetails.Sum(od => od.Quantity * od.UnitPrice);

        // Create OrderDetails from the DTO
        foreach (OrderDetail detail in orderCreateDto.OrderDetails)
        {
            order.OrderDetails?.Add(new OrderDetail
            {
                ProductId = detail.ProductId,
                Quantity = detail.Quantity,
                UnitPrice = detail.UnitPrice,
            });
            Console.WriteLine(order.OrderDetails);
        }

        // Add the order to the context
        _context.Orders.Add(order);
        // Save changes to the database
        await _context.SaveChangesAsync();

        foreach (var detail in orderCreateDto.OrderDetails)
        {
            var orderDetail = new OrderDetail
            {
                ProductId = detail.ProductId,
                Quantity = detail.Quantity,
                UnitPrice = detail.UnitPrice,
                OrderId = order.ID_Order // Assuming you have the Order ID here
            };

            _context.OrderDetails.Add(orderDetail);
        }

        // Save changes to the database
        await _context.SaveChangesAsync();

        // Return the created order with a 201 Created response
        return CreatedAtAction(nameof(GetOrder), new { id = order.ID_Order }, order);
    }

    // GET: api/orders/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Auto == id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }
}
