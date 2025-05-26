using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Domain.ContractorsAggregate;
using MikeyaWarehouse.Domain.ContractorsAggregate.Entities;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Domain.PalletAggregate.Entities;
using MikeyaWarehouse.Domain.WarehouseAggregate;
using MikeyaWarehouse.Infrastructure.Persistence.Configurations.ModelsConfigurations;

namespace MikeyaWarehouse.Infrastructure.Persistence;

public class MikeyaWarehouseDbContext : DbContext
{
    public DbSet<Contractor> ContractorSet { get; set; } = null!;
    public DbSet<Pallet> Pallets{ get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Shipment> Shipments { get; set; } = null!;
    public DbSet<Warehouse> Warehouses { get; set; } = null!;

    public MikeyaWarehouseDbContext(
        DbContextOptions<MikeyaWarehouseDbContext> options)
        : base(options) 
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PalletsTableConfiguration());
        modelBuilder.ApplyConfiguration(new WarehousesTableConfiguration());
        modelBuilder.ApplyConfiguration(new ContractorsTableConfiguration());


        base.OnModelCreating(modelBuilder);
    }




}
