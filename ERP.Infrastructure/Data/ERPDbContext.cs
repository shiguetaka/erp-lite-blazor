using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Data;

public class ERPDbContext : DbContext
{
    public ERPDbContext(
        DbContextOptions<ERPDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Venda>()
        .HasOne(x => x.Cliente)
        .WithMany()
        .HasForeignKey(x => x.ClienteId);

    modelBuilder.Entity<Venda>()
        .HasOne(x => x.Produto)
        .WithMany()
        .HasForeignKey(x => x.ProdutoId);
}

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Venda> Vendas { get; set; }
}