public class Inventario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Tipo { get; set; }   // Carne, Ingrediente, Empaque, etc.
    public string Unidad { get; set; } // lb, unidad, caja, etc.
    public decimal Cantidad { get; set; }
}
