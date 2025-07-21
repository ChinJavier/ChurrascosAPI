public class PedidoChurrasco
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; }
    public int ChurrascoId { get; set; }
    public Churrasco Churrasco { get; set; }
}