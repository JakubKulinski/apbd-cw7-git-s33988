using apbd_cw7_git_s33988.DTOs;
using apbd_cw7_git_s33988.Exceptions;
using apbd_cw7_git_s33988.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_cw7_git_s33988.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PcsController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public PcsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPcs()
    {
        var result = await _dbService.GetAllAsync();
        return Ok(result);
    }
    
    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetComponents(int id)
    {
        try
        {
            var components = await _dbService.GetComponentsByPcIdAsync(id);
            return Ok(components);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePcRequestDto dto)
    {
        var created = await _dbService.CreateAsync(dto);
        return Created($"/api/pcs/{created.Id}", created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePcRequestDto dto)
    {
        try
        {
            await _dbService.UpdateAsync(id, dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _dbService.DeleteAsync(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}