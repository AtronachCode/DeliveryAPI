using DeliveryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DeliveryAPI.Context;

public class DeliveryDbContext : DbContext
{
    public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
}
