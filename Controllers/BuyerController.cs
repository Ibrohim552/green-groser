using FarmConnect.Domain;
using FarmConnect.Infrastructure.Services.BuyerService;
using Microsoft.AspNetCore.Mvc;

namespace FarmConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuyersController : ControllerBase
{
    private readonly IBuyerService _buyerService;

    public BuyersController(IBuyerService buyerService)
    {
        _buyerService = buyerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var buyers = await _buyerService.GetAllBuyersAsync();
        return Ok(buyers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var buyer = await _buyerService.GetBuyerByIdAsync(id);
        if (buyer == null) return NotFound();
        return Ok(buyer);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Buyer buyer)
    {
        if (buyer == null) return BadRequest();
        await _buyerService.CreateBuyerAsync(buyer);
        return CreatedAtAction(nameof(GetById), new { id = buyer.Id }, buyer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Buyer buyer)
    {
        if (buyer == null || id != buyer.Id) return BadRequest();
        await _buyerService.UpdateBuyerAsync(buyer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _buyerService.DeleteBuyerAsync(id);
        return NoContent();
    }
}
