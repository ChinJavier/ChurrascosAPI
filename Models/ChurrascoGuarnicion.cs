public class ChurrascoGuarnicion
{
    public int Id { get; set; }

    public int ChurrascoId { get; set; }
    public Churrasco Churrasco { get; set; }

    public int GuarnicionId { get; set; }
    public Guarnicion Guarnicion { get; set; }

    public bool EsExtra { get; set; } = false;
}