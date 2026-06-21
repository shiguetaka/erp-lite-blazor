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

    public DbSet<Cliente> Clientes { get; set; }
}