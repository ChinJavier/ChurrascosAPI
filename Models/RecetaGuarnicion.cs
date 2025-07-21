namespace TiendaChurrascosApi.Models;

public class RecetaGuarnicion
{
    public int Id { get; set; }

    public string Guarnicion { get; set; } = string.Empty;     // Ej: "Frijoles"
    public string UnidadInventario { get; set; } = string.Empty; // Ej: "taza"
    public decimal CantidadPorPorcion { get; set; } // Ej: 1.0
}