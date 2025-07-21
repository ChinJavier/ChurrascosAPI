namespace TiendaChurrascosApi.DTOs;

public class PedidoDto
{
    public string Tipo { get; set; } = "Individual"; // "Individual" o "Combo"

    // Para pedidos individuales
    public List<int>? ChurrascosIds { get; set; }
    public List<DulcePedidoDto>? Dulces { get; set; }

    // Para pedidos de combo
    public int? ComboId { get; set; }
    public int? Cantidad { get; set; }

    public decimal Total { get; set; }
}
