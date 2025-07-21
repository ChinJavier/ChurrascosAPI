using Microsoft.EntityFrameworkCore;
using TiendaChurrascosApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // Productos
    public DbSet<Churrasco> Churrascos { get; set; }
    public DbSet<DulceTipico> Dulces { get; set; }
    public DbSet<Guarnicion> Guarniciones { get; set; }

    // Relaciones
    public DbSet<ChurrascoGuarnicion> ChurrascoGuarniciones { get; set; }
    public DbSet<Combo> Combos { get; set; }
    public DbSet<ComboChurrasco> ComboChurrascos { get; set; }
    public DbSet<ComboDulce> ComboDulces { get; set; }

    // Pedidos / ventas
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoChurrasco> PedidoChurrascos { get; set; }
    public DbSet<PedidoDulce> PedidoDulces { get; set; }

    // Inventario e insumos
    public DbSet<Inventario> Inventario { get; set; }
    public DbSet<ConsumoCarne> ConsumoCarnes { get; set; }
    public DbSet<RecetaGuarnicion> RecetaGuarniciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Claves compuestas
        modelBuilder.Entity<PedidoChurrasco>()
            .HasKey(pc => new { pc.PedidoId, pc.ChurrascoId });

        modelBuilder.Entity<PedidoDulce>()
            .HasKey(pd => new { pd.PedidoId, pd.DulceTipicoId });

        modelBuilder.Entity<ChurrascoGuarnicion>()
            .HasOne(cg => cg.Churrasco)
            .WithMany(c => c.Guarniciones)
            .HasForeignKey(cg => cg.ChurrascoId);

        modelBuilder.Entity<ChurrascoGuarnicion>()
            .HasOne(cg => cg.Guarnicion)
            .WithMany(g => g.Churrascos)
            .HasForeignKey(cg => cg.GuarnicionId);

        modelBuilder.Entity<ComboChurrasco>()
            .HasOne(cc => cc.Combo)
            .WithMany(c => c.Churrascos)
            .HasForeignKey(cc => cc.ComboId);

        modelBuilder.Entity<ComboChurrasco>()
            .HasOne(cc => cc.Churrasco)
            .WithMany()
            .HasForeignKey(cc => cc.ChurrascoId);

        modelBuilder.Entity<ComboDulce>()
            .HasOne(cd => cd.Combo)
            .WithMany(c => c.Dulces)
            .HasForeignKey(cd => cd.ComboId);

        modelBuilder.Entity<ComboDulce>()
            .HasOne(cd => cd.DulceTipico)
            .WithMany()
            .HasForeignKey(cd => cd.DulceTipicoId);
    }
}
