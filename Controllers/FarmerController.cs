using FarmConnect.Domain;
using FarmConnect.Infrastructure.Services.FarmerService;
using Microsoft.AspNetCore.Mvc;

namespace FarmConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FarmersController : ControllerBase
{
    private readonly IFarmerService _farmerService;

    public FarmersController(IFarmerService farmerService)
    {
        _farmerService = farmerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var farmers = await _farmerService.GetAllFarmersAsync();
        return Ok(farmers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var farmer = await _farmerService.GetFarmerByIdAsync(id);
        if (farmer == null) return NotFound();
        return Ok(farmer);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Farmer farmer)
    {
        if (farmer == null) return BadRequest();
        await _farmerService.CreateFarmerAsync(farmer);
        return CreatedAtAction(nameof(GetById), new { id = farmer.Id }, farmer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Farmer farmer)
    {
        if (farmer == null || id != farmer.Id) return BadRequest();
        await _farmerService.UpdateFarmerAsync(farmer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _farmerService.DeleteFarmerAsync(id);
        return NoContent();
    }
}
