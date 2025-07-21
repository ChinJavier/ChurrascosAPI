namespace TiendaChurrascosApi.Models
{
    public class Churrasco
    {
        public int Id { get; set; }
        public string TipoCarne { get; set; }  // Puyazo, Culotte, Costilla
        public string Termino { get; set; }    // Medio, tres cuartos, bien cocido
        public string Modalidad { get; set; }  // Individual / Familiar
        public int Porciones { get; set; }
        public List<string> Guarniciones { get; set; }
    }
}
