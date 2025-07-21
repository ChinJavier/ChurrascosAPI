namespace TiendaChurrascosApi.Models;

public class Churrasco
{
    public int Id { get; set; }
    public string TipoCarne { get; set; }  // Puyazo, Culotte, Costilla
    public string Termino { get; set; }    // Término medio, etc.
    public string Modalidad { get; set; }  // Individual, Familiar
    public int Porciones { get; set; }

    // Por ahora simplificamos las guarniciones como JSON
    public List<string> Guarniciones { get; set; } = new();
}
