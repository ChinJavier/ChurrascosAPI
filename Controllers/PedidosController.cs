using Microsoft.AspNetCore.Mvc;
using TiendaChurrascosApi.Services;

namespace TiendaChurrascosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly PedidoService _pedidoService;

    public PedidoController(PedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpPost]
    public async Task<IActionResult> CrearPedido([FromBody] CrearPedidoDTO dto)
    {
        var resultado = await _pedidoService.CrearPedidoAsync(dto);

        if (!resultado.Exito)
            return BadRequest(new { mensaje = resultado.Mensaje });

        return Ok(new
        {
            mensaje = "Pedido creado exitosamente",
            pedidoId = resultado.Pedido.Id,
            total = resultado.Pedido.Total
        });
    }
}
