public class Guarnicion
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public ICollection<ChurrascoGuarnicion> Churrascos { get; set; }
}
