namespace TiendaChurrascosApi.Models;

public class ConsumoCarne
{
    public int Id { get; set; }

    public string TipoCarne { get; set; } = string.Empty; // Ej: "Puyazo"
    public decimal LibrasPorPorcion { get; set; } // Ej: 0.4
}
