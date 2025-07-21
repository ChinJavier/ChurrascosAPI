namespace TiendaChurrascosApi.Models;

public class Inventario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Tipo { get; set; }  // "Carne", "Dulce", "Ingrediente", "Empaque"
    public string Unidad { get; set; }  // "lb", "unidad", etc.
    public decimal Cantidad { get; set; }
}
