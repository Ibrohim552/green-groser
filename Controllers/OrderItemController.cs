using FarmConnect.Domain;
using FarmConnect.Infrastructure.Services.OrderItemService;
using Microsoft.AspNetCore.Mvc;

namespace FarmConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemsController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;

    public OrderItemsController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orderItems = await _orderItemService.GetAllOrderItemsAsync();
        return Ok(orderItems);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
        if (orderItem == null) return NotFound();
        return Ok(orderItem);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderItem orderItem)
    {
        if (orderItem == null) return BadRequest();
        await _orderItemService.CreateOrderItemAsync(orderItem);
        return CreatedAtAction(nameof(GetById), new { id = orderItem.Id }, orderItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrderItem orderItem)
    {
        if (orderItem == null || id != orderItem.Id) return BadRequest();
        await _orderItemService.UpdateOrderItemAsync(orderItem);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _orderItemService.DeleteOrderItemAsync(id);
        return NoContent();
    }
}
