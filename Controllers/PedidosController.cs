using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaChurrascosApi.DTOs;
using TiendaChurrascosApi.Models;
using TiendaChurrascosApi.Services;

namespace TiendaChurrascosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly PedidoService _pedidoService;

    public PedidosController(ApplicationDbContext context, PedidoService pedidoService)
    {
        _context = context;
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
    {
        return await _context.Pedidos
            .Include(p => p.Churrascos)
            .Include(p => p.Dulces)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> CrearPedido([FromBody] PedidoDto pedidoDto)
    {
        var result = await _pedidoService.CrearPedidoAsync(pedidoDto);

        if (!result.Exito)
            return BadRequest(result.Mensaje);

        return Ok(result.Pedido);
    }
}
