using Microsoft.EntityFrameworkCore;

public class PlazaDbContext : DbContext
{
    public PlazaDbContext(DbContextOptions<PlazaDbContext> options) : base(options)
    {
    }

    public DbSet<Producto> Productos => Set<Producto>();

    protected override void OnModelCreating(ModelBuilder modelo)
    {
        modelo.Entity<Producto>().Property(p => p.Nombre).HasMaxLength(60);
        modelo.Entity<Producto>().Property(p => p.Precio).HasPrecision(10, 2);

        modelo.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Tomate", Precio = 3500m },
            new Producto { Id = 2, Nombre = "Aguacate", Precio = 6000m },
            new Producto { Id = 3, Nombre = "Papa", Precio = 2800m },
            new Producto { Id = 4, Nombre = "Panela", Precio = 4500m });
    }
}