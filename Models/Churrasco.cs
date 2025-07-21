public class Churrasco
{
    public int Id { get; set; }
    public string TipoCarne { get; set; }
    public string Termino { get; set; }
    public string Modalidad { get; set; } // Individual / Familiar
    public int Porciones { get; set; }
    public decimal TotalPrecio { get; set; }

    public ICollection<ChurrascoGuarnicion> Guarniciones { get; set; } = new List<ChurrascoGuarnicion>();
}
