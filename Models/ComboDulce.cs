public class ComboDulce
{
    public int Id { get; set; }
    public int ComboId { get; set; }
    public Combo Combo { get; set; }

    public int DulceTipicoId { get; set; }
    public DulceTipico DulceTipico { get; set; }

    public int TamañoCaja { get; set; } // 6, 12, 24
}