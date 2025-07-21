public class PedidoDulce
{
    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; }

    public int DulceTipicoId { get; set; }
    public DulceTipico DulceTipico { get; set; }

    public int Cantidad { get; set; }
    public int TamañoCaja { get; set; } // 6, 12, 24
}