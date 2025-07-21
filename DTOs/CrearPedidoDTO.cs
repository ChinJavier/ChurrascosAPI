public class CrearPedidoDTO
{
    public string Tipo { get; set; } = string.Empty; // "Individual" o "Combo"

    public int? ComboId { get; set; }
    public int? CantidadCombo { get; set; }

    public List<ChurrascoPedidoDTO> Churrascos { get; set; } = new();
    public List<DulcePedidoDTO> Dulces { get; set; } = new();
} 