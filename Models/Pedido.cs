public class Pedido
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }
    public string Tipo { get; set; } = "Individual";

    public ICollection<PedidoChurrasco> Churrascos { get; set; } = new List<PedidoChurrasco>();
    public ICollection<PedidoDulce> Dulces { get; set; } = new List<PedidoDulce>();

    public int? ComboId { get; set; }
    public Combo? Combo { get; set; }
    public int? CantidadCombo { get; set; }
}
