using Microsoft.EntityFrameworkCore;
using TiendaChurrascosApi.Models;

namespace TiendaChurrascosApi.Services;

public class PedidoService
{
    private readonly ApplicationDbContext _context;

    public PedidoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultadoPedido> CrearPedidoAsync(CrearPedidoDTO dto)
    {
        var pedido = new Pedido
        {
            Fecha = DateTime.UtcNow,
            Tipo = dto.Tipo
        };

        if (dto.Tipo == "Combo" && dto.ComboId.HasValue)
        {
            var combo = await _context.Combos
                .Include(c => c.ComboChurrascos)
                .Include(c => c.ComboDulces)
                .FirstOrDefaultAsync(c => c.Id == dto.ComboId.Value);

            if (combo == null)
                return ResultadoPedido.Fallo("Combo no encontrado.");

            pedido.ComboId = combo.Id;
            pedido.CantidadCombo = dto.CantidadCombo ?? 1;
            pedido.Total = combo.Precio * pedido.CantidadCombo.Value;
        }
        else
        {
            decimal total = 0;

            foreach (var churrascoDto in dto.Churrascos)
            {
                var churrasco = await _context.Churrascos.FindAsync(churrascoDto.ChurrascoId);
                if (churrasco == null)
                    return ResultadoPedido.Fallo($"Churrasco con ID {churrascoDto.ChurrascoId} no encontrado.");

                pedido.Churrascos.Add(new PedidoChurrasco
                {
                    ChurrascoId = churrasco.Id
                });

                total += churrasco.TotalPrecio;
            }

            foreach (var dulceDto in dto.Dulces)
            {
                var dulce = await _context.Dulces.FindAsync(dulceDto.DulceTipicoId);
                if (dulce == null)
                    return ResultadoPedido.Fallo($"Dulce con ID {dulceDto.DulceTipicoId} no encontrado.");

                decimal precio = dulceDto.TamañoCaja switch
                {
                    6 => dulce.PrecioCaja6,
                    12 => dulce.PrecioCaja12,
                    24 => dulce.PrecioCaja24,
                    _ => dulce.PrecioUnidad * dulceDto.Cantidad
                };

                pedido.Dulces.Add(new PedidoDulce
                {
                    DulceTipicoId = dulce.Id,
                    Cantidad = dulceDto.Cantidad,
                    TamañoCaja = dulceDto.TamañoCaja
                });

                total += precio;
            }

            pedido.Total = total;
        }

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();

        return ResultadoPedido.CrearExito(pedido);
    }
}
