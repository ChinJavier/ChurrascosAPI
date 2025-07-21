using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaChurrascosApi.Models;

namespace TiendaChurrascosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChurrascosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ChurrascosController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Churrasco>>> GetAll()
    {
        return await _context.Churrascos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Churrasco>> Get(int id)
    {
        var churrasco = await _context.Churrascos.FindAsync(id);
        if (churrasco == null) return NotFound();
        return churrasco;
    }

    [HttpPost]
    public async Task<ActionResult<Churrasco>> Post(Churrasco churrasco)
    {
        _context.Churrascos.Add(churrasco);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = churrasco.Id }, churrasco);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Churrasco updated)
    {
        if (id != updated.Id) return BadRequest();

        _context.Entry(updated).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Churrascos.Any(e => e.Id == id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var churrasco = await _context.Churrascos.FindAsync(id);
        if (churrasco == null) return NotFound();

        _context.Churrascos.Remove(churrasco);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
