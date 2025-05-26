using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MikeyaWarehouse.Infrastructure.Persistence;

public class MikeyaWarehouseDesignTimeDbContextFactory
    : IDesignTimeDbContextFactory<MikeyaWarehouseDbContext>
{
    public MikeyaWarehouseDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MikeyaWarehouseDbContext>();
        var connectionString = "Host=localhost;Port=5432;Database=MikeyaWarehouseDb;Username=mikeyaUser;Password=mikeyA1234";
        
        optionsBuilder.UseNpgsql(connectionString,
            cfg => cfg.EnableRetryOnFailure(2));

        return new MikeyaWarehouseDbContext(optionsBuilder.Options);
    }
}
