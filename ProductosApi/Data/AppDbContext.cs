using Microsoft.EntityFrameworkCore;
using ProductosApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> o) : base(o) { }

    public DbSet<Producto> Productos => Set<Producto>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Producto>().HasData(
            new Producto { Id=1, Nombre="Laptop Pro",  Precio=1299.99m, Stock=15, Categoria="Electrónica" },
            new Producto { Id=2, Nombre="Mouse Gamer", Precio=49.99m,  Stock=80, Categoria="Periféricos" },
            new Producto { Id=3, Nombre="Teclado RGB", Precio=89.99m,  Stock=45, Categoria="Periféricos" }
        );
    }
}