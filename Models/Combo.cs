public class Combo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public string? Tipo { get; set; }

    public ICollection<ComboChurrasco> ComboChurrascos { get; set; } = new List<ComboChurrasco>();
    public ICollection<ComboDulce> ComboDulces { get; set; } = new List<ComboDulce>();
}