using TiendaChurrascosApi.Models;

namespace TiendaChurrascosApi.Data;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        if (!context.Inventario.Any())
        {
            context.Inventario.AddRange(
                new Inventario { Nombre = "Puyazo", Tipo = "Carne", Unidad = "lb", Cantidad = 50 },
                new Inventario { Nombre = "Costilla", Tipo = "Carne", Unidad = "lb", Cantidad = 60 },
                new Inventario { Nombre = "Culotte", Tipo = "Carne", Unidad = "lb", Cantidad = 40 },
                new Inventario { Nombre = "Frijoles", Tipo = "Ingrediente", Unidad = "taza", Cantidad = 100 },
                new Inventario { Nombre = "Cebollín", Tipo = "Ingrediente", Unidad = "unidad", Cantidad = 100 },
                new Inventario { Nombre = "Tortillas", Tipo = "Ingrediente", Unidad = "unidad", Cantidad = 300 },
                new Inventario { Nombre = "Chirmol", Tipo = "Ingrediente", Unidad = "cucharón", Cantidad = 100 },
                new Inventario { Nombre = "Caja 6", Tipo = "Empaque", Unidad = "unidad", Cantidad = 50 },
                new Inventario { Nombre = "Caja 12", Tipo = "Empaque", Unidad = "unidad", Cantidad = 30 },
                new Inventario { Nombre = "Caja 24", Tipo = "Empaque", Unidad = "unidad", Cantidad = 20 },
                new Inventario { Nombre = "Carbón", Tipo = "Combustible", Unidad = "lb", Cantidad = 80 }
            );
        }

        if (!context.ConsumoCarnes.Any())
        {
            context.ConsumoCarnes.AddRange(
                new ConsumoCarne { TipoCarne = "Puyazo", LibrasPorPorcion = 0.4m },
                new ConsumoCarne { TipoCarne = "Culotte", LibrasPorPorcion = 0.35m },
                new ConsumoCarne { TipoCarne = "Costilla", LibrasPorPorcion = 0.5m }
            );
        }

        if (!context.RecetaGuarniciones.Any())
        {
            context.RecetaGuarniciones.AddRange(
                new RecetaGuarnicion { Guarnicion = "Frijoles", UnidadInventario = "taza", CantidadPorPorcion = 1 },
                new RecetaGuarnicion { Guarnicion = "Cebollín", UnidadInventario = "unidad", CantidadPorPorcion = 1 },
                new RecetaGuarnicion { Guarnicion = "Chirmol", UnidadInventario = "cucharón", CantidadPorPorcion = 0.5m },
                new RecetaGuarnicion { Guarnicion = "Tortillas", UnidadInventario = "unidad", CantidadPorPorcion = 2 }
            );
        }

        if (!context.Dulces.Any())
        {
            context.Dulces.AddRange(
                new DulceTipico { Nombre = "Canillitas de leche", PrecioUnidad = 1.5m, PrecioCaja6 = 8, PrecioCaja12 = 15, PrecioCaja24 = 28 },
                new DulceTipico { Nombre = "Pepitoria", PrecioUnidad = 1.2m, PrecioCaja6 = 7, PrecioCaja12 = 13, PrecioCaja24 = 25 },
                new DulceTipico { Nombre = "Cocadas", PrecioUnidad = 1.4m, PrecioCaja6 = 8, PrecioCaja12 = 14, PrecioCaja24 = 26 },
                new DulceTipico { Nombre = "Dulces de higo", PrecioUnidad = 1.6m, PrecioCaja6 = 9, PrecioCaja12 = 16, PrecioCaja24 = 30 },
                new DulceTipico { Nombre = "Mazapanes", PrecioUnidad = 1.3m, PrecioCaja6 = 7, PrecioCaja12 = 13, PrecioCaja24 = 24 },
                new DulceTipico { Nombre = "Chilacayotes", PrecioUnidad = 1.7m, PrecioCaja6 = 9, PrecioCaja12 = 17, PrecioCaja24 = 32 },
                new DulceTipico { Nombre = "Conservas de coco", PrecioUnidad = 1.5m, PrecioCaja6 = 8, PrecioCaja12 = 15, PrecioCaja24 = 28 },
                new DulceTipico { Nombre = "Colochos de guayaba", PrecioUnidad = 1.6m, PrecioCaja6 = 9, PrecioCaja12 = 16, PrecioCaja24 = 29 }
            );
        }

        context.SaveChanges();

        if (!context.Churrascos.Any())
        {
            var g1 = new Guarnicion { Nombre = "Frijoles" };
            var g2 = new Guarnicion { Nombre = "Tortillas" };
            var g3 = new Guarnicion { Nombre = "Cebollín" };
            var g4 = new Guarnicion { Nombre = "Chirmol" };

            var churrasco1 = new Churrasco { TipoCarne = "Puyazo", Termino = "Tres cuartos", Modalidad = "Familiar", Porciones = 3, TotalPrecio = 95 };
            churrasco1.Guarniciones.Add(new ChurrascoGuarnicion { Guarnicion = g1 });
            churrasco1.Guarniciones.Add(new ChurrascoGuarnicion { Guarnicion = g2 });

            var churrasco2 = new Churrasco { TipoCarne = "Costilla", Termino = "Bien cocido", Modalidad = "Familiar", Porciones = 5, TotalPrecio = 135 };
            churrasco2.Guarniciones.Add(new ChurrascoGuarnicion { Guarnicion = g3 });
            churrasco2.Guarniciones.Add(new ChurrascoGuarnicion { Guarnicion = g4 });

            context.Churrascos.AddRange(churrasco1, churrasco2);
            context.SaveChanges();
        }

        if (!context.Combos.Any())
        {
            var combo = new Combo { Nombre = "Combo Familiar", Descripcion = "1 churrasco familiar de Puyazo + 1 caja de canillitas", Precio = 110 };
            context.Combos.Add(combo);
            context.SaveChanges();

            var churrasco = context.Churrascos.First();
            var dulce = context.Dulces.First();

            context.ComboChurrascos.Add(new ComboChurrasco { ComboId = combo.Id, ChurrascoId = churrasco.Id });
            context.ComboDulces.Add(new ComboDulce { ComboId = combo.Id, DulceTipicoId = dulce.Id, TamañoCaja = 12 });
            context.SaveChanges();
        }

        if (!context.Pedidos.Any())
        {
            var combo = context.Combos.First();
            var pedido = new Pedido { Tipo = "Combo", Fecha = DateTime.UtcNow, Total = combo.Precio, ComboId = combo.Id, CantidadCombo = 1 };
            context.Pedidos.Add(pedido);
            context.SaveChanges();
        }
    }
}