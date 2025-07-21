using Microsoft.EntityFrameworkCore;
using TiendaChurrascosApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {}

    public DbSet<Churrasco> Churrascos { get; set; }
    // public DbSet<DulceTipico> Dulces { get; set; }
    // public DbSet<Combo> Combos { get; set; }
    // public DbSet<Inventario> Inventario { get; set; }
}
