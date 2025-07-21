public class Combo
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Tipo { get; set; } // Familiar, Evento, Personalizado
    public decimal PrecioTotal { get; set; }

    public ICollection<ComboChurrasco> Churrascos { get; set; }
    public ICollection<ComboDulce> Dulces { get; set; }
}
