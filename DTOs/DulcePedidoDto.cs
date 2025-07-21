namespace TiendaChurrascosApi.DTOs;

public class DulcePedidoDto
{
    public int DulceTipicoId { get; set; }
    public int Cantidad { get; set; }
    public int? TamañoCaja { get; set; } // Null si es unidad suelta
}
