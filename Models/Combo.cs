namespace TiendaChurrascosApi.Models;

public class Combo
{
    public int Id { get; set; }
    public string Nombre { get; set; }  // Ej. "Combo Familiar"
    public string Descripcion { get; set; }

    public List<Churrasco> Churrascos { get; set; } = new();
    public List<DulceTipico> Dulces { get; set; } = new();
}
