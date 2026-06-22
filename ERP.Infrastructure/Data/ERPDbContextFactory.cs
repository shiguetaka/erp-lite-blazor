using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ERP.Infrastructure.Data;

public class ERPDbContextFactory : IDesignTimeDbContextFactory<ERPDbContext>
{
    public ERPDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ERPDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=ERP_Lite;User Id=sa;Password=@dmin123;TrustServerCertificate=True;"
        );

        return new ERPDbContext(optionsBuilder.Options);
    }
}