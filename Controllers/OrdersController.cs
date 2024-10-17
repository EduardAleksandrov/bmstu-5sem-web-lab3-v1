using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DBase.Models;
using DBase.Data;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ILogger<OrdersController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // [HttpGet("id", Name = "GetWeatherForecast")]
    // // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
    // [HttpGet("products", Name = "GetProducts")]
    // public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    // {
    //     return await _context.Products.ToListAsync();
    // }

    // POST: api/orders/
    [HttpPost(Name = "AddOrder")]
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
    [HttpGet("{id}", Name = "GetOrderById")]
    public async Task<ActionResult<Order>> GetOrder(Guid id)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.ID_Order == id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }
    // GET: api/orders/
    [HttpGet(Name = "GetOrders")]
    public async Task<ActionResult<Order>> GetOrders()
    {
        var order = await _context.Orders.ToListAsync();

        if (order == null || !order.Any())
        {
            return NotFound();
        }

        return Ok(order);
    }

    // PUT: api/orders/{id}
    [HttpPut("{id}", Name = "UpdateOrder")]
    public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] Order order)
    {
        if (id != order.ID_Order)
        {
            return BadRequest("Order ID mismatch.");
        }

        // Check if the order exists
        var existingOrder = await _context.Orders.FindAsync(id);
        if (existingOrder == null)
        {
            return NotFound();
        }

        // Update the properties of the existing order
        existingOrder.Status = order.Status;

        // Update the order details if necessary
        // You may want to handle this based on your business logic

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent(); // 204 No Content
    }

    private bool OrderExists(Guid id)
    {
        return _context.Orders.Any(e => e.ID_Order == id);
    }

    // DELETE: api/orders/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return NotFound(); // Return 404 if the order is not found
        }
        
        // Find the order including its order details
        var orderDetails = await _context.OrderDetails
            .Where(od => od.OrderId == id) // Filter by OrderId
            .ToListAsync();

        if (orderDetails == null)
        {
            return NotFound(); // Return 404 if the order is not found
        }

        // Remove associated OrderDetails
        if (orderDetails != null && orderDetails.Any())
        {
            _context.OrderDetails.RemoveRange(orderDetails); // Remove all related OrderDetails
        }

        _context.Orders.Remove(order); // Remove the order from the context
        await _context.SaveChangesAsync(); // Save changes to the database

        return NoContent(); // Return 204 No Content
    }

    // OPTIONS: api/orders
    [HttpOptions]
    public IActionResult Options()
    {
        // Define the allowed HTTP methods for this endpoint
        Response.Headers.Append("Allow", "GET, POST, PUT, DELETE, OPTIONS");
        return Ok(); // Return 200 OK
    }


}
