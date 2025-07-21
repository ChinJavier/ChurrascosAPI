using TiendaChurrascosApi.Models;
using TiendaChurrascosApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace TiendaChurrascosApi.Services;

public class PedidoService
{
    private readonly ApplicationDbContext _context;

    public PedidoService(ApplicationDbContext context)
    {
        _context = context;
    }

public async Task<ResultadoPedido> CrearPedidoAsync(PedidoDto dto)
{
    using var transaction = await _context.Database.BeginTransactionAsync();

    try
    {
        var pedido = new Pedido
        {
            Tipo = dto.Tipo,
            Fecha = DateTime.UtcNow,
            Total = dto.Total
        };

        // Lógica para pedidos tipo "Combo"
        if (dto.Tipo.ToLower() == "combo")
        {
            if (dto.ComboId == null || dto.Cantidad == null)
                return ResultadoPedido.Fallo("Debe indicar ComboId y Cantidad para un pedido de tipo combo.");

            var combo = await _context.Combos
                .Include(c => c.ComboChurrascos)
                .Include(c => c.ComboDulces)
                .FirstOrDefaultAsync(c => c.Id == dto.ComboId);

            if (combo == null)
                return ResultadoPedido.Fallo($"No se encontró el combo con ID {dto.ComboId}");

            pedido.ComboId = combo.Id;
            pedido.Combo = combo;
            pedido.CantidadCombo = dto.Cantidad;

            // Agregar churrascos del combo
            foreach (var cc in combo.ComboChurrascos)
            {
                var churrasco = cc.Churrasco;
                for (int i = 0; i < dto.Cantidad; i++)
                {
                    _context.PedidoChurrascos.Add(new PedidoChurrasco
                    {
                        Pedido = pedido,
                        ChurrascoId = churrasco.Id
                    });

                    // Descontar carne
                    var consumo = await _context.ConsumoCarnes.FirstOrDefaultAsync(c => c.TipoCarne == churrasco.TipoCarne);
                    if (consumo == null)
                        return ResultadoPedido.Fallo($"No se definió el consumo para {churrasco.TipoCarne}");

                    var carneInventario = await _context.Inventario.FirstOrDefaultAsync(i => i.Nombre == churrasco.TipoCarne);
                    var requerido = consumo.LibrasPorPorcion * churrasco.Porciones;
                    if (carneInventario == null || carneInventario.Cantidad < requerido)
                        return ResultadoPedido.Fallo($"Inventario insuficiente de {churrasco.TipoCarne}");

                    carneInventario.Cantidad -= requerido;
                }
            }

            // Agregar dulces del combo
            foreach (var cd in combo.ComboDulces)
            {
                var dulce = cd.DulceTipico;

                _context.PedidoDulces.Add(new PedidoDulce
                {
                    Pedido = pedido,
                    DulceTipicoId = dulce.Id,
                    Cantidad = cd.Cantidad * dto.Cantidad.Value,
                    TamañoCaja = cd.TamañoCaja
                });

                int totalUnidades = cd.Cantidad * dto.Cantidad.Value * (cd.TamañoCaja ?? 1);
                var dulceInventario = await _context.Inventario.FirstOrDefaultAsync(i => i.Nombre == dulce.Nombre && i.Tipo == "Dulce");

                if (dulceInventario == null || dulceInventario.Cantidad < totalUnidades)
                    return ResultadoPedido.Fallo($"Inventario insuficiente de {dulce.Nombre}");

                dulceInventario.Cantidad -= totalUnidades;
            }
        }
        else
        {
            // Lógica para pedidos individuales (igual que antes)
            if (dto.ChurrascosIds != null)
            {
                foreach (var id in dto.ChurrascosIds)
                {
                    var churrasco = await _context.Churrascos.FindAsync(id);
                    if (churrasco == null)
                        return ResultadoPedido.Fallo($"Churrasco con ID {id} no encontrado");

                    _context.PedidoChurrascos.Add(new PedidoChurrasco
                    {
                        Pedido = pedido,
                        ChurrascoId = id
                    });

                    var consumo = await _context.ConsumoCarnes.FirstOrDefaultAsync(c => c.TipoCarne == churrasco.TipoCarne);
                    if (consumo == null)
                        return ResultadoPedido.Fallo($"Consumo no definido para {churrasco.TipoCarne}");

                    var carneInv = await _context.Inventario.FirstOrDefaultAsync(i => i.Nombre == churrasco.TipoCarne);
                    var requerido = consumo.LibrasPorPorcion * churrasco.Porciones;
                    if (carneInv == null || carneInv.Cantidad < requerido)
                        return ResultadoPedido.Fallo($"Inventario insuficiente para {churrasco.TipoCarne}");

                    carneInv.Cantidad -= requerido;
                }
            }

            if (dto.Dulces != null)
            {
                foreach (var dulceDto in dto.Dulces)
                {
                    var d = await _context.Dulces.FindAsync(dulceDto.DulceTipicoId);
                    if (d == null)
                        return ResultadoPedido.Fallo($"Dulce con ID {dulceDto.DulceTipicoId} no encontrado");

                    _context.PedidoDulces.Add(new PedidoDulce
                    {
                        Pedido = pedido,
                        DulceTipicoId = d.Id,
                        Cantidad = dulceDto.Cantidad,
                        TamañoCaja = dulceDto.TamañoCaja
                    });

                    int unidades = dulceDto.TamañoCaja.HasValue ? dulceDto.Cantidad * dulceDto.TamañoCaja.Value : dulceDto.Cantidad;

                    var dulceInv = await _context.Inventario.FirstOrDefaultAsync(i => i.Nombre == d.Nombre && i.Tipo == "Dulce");
                    if (dulceInv == null || dulceInv.Cantidad < unidades)
                        return ResultadoPedido.Fallo($"Inventario insuficiente para {d.Nombre}");

                    dulceInv.Cantidad -= unidades;
                }
            }
        }

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        return ResultadoPedido.CrearExito(pedido);
    }
    catch (Exception ex)
    {
        await transaction.RollbackAsync();
        return ResultadoPedido.Fallo("Error al procesar el pedido: " + ex.Message);
    }
}


}
