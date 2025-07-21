public class Pedido
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }
    public string Tipo { get; set; }  // Churrasco / Combo / Dulce

    public ICollection<PedidoChurrasco> Churrascos { get; set; }
    public ICollection<PedidoDulce> Dulces { get; set; }
}
