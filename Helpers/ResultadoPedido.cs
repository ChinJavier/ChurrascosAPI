namespace TiendaChurrascosApi.Models;

public class ResultadoPedido
{
    public bool Exito { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public Pedido? Pedido { get; set; }

    public static ResultadoPedido CrearExito(Pedido pedido) =>
        new ResultadoPedido { Exito = true, Pedido = pedido };

    public static ResultadoPedido Fallo(string mensaje) =>
        new ResultadoPedido { Exito = false, Mensaje = mensaje };
}
