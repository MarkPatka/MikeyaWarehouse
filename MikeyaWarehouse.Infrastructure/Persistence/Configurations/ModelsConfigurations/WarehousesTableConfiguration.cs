using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MikeyaWarehouse.Domain.WarehouseAggregate;

namespace MikeyaWarehouse.Infrastructure.Persistence.Configurations.ModelsConfigurations;

public class WarehousesTableConfiguration
    : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        ConfigureBufferZonesTable(builder);
        ConfigureRampsTable(builder);
        ConfigureStorageBinsTable(builder);
        ConfigureStorageSectionsTable(builder);
        ConfigureStorageRacksTable(builder);
        ConfigureStorageZonesTable(builder);
    }

    private void ConfigureStorageZonesTable(EntityTypeBuilder<Warehouse> builder)
    {
        throw new NotImplementedException();
    }

    private void ConfigureStorageSectionsTable(EntityTypeBuilder<Warehouse> builder)
    {
        throw new NotImplementedException();
    }

    private void ConfigureStorageRacksTable(EntityTypeBuilder<Warehouse> builder)
    {
        throw new NotImplementedException();
    }

    private void ConfigureStorageBinsTable(EntityTypeBuilder<Warehouse> builder)
    {
        throw new NotImplementedException();
    }

    private void ConfigureRampsTable(EntityTypeBuilder<Warehouse> builder)
    {
        throw new NotImplementedException();
    }

    private void ConfigureBufferZonesTable(EntityTypeBuilder<Warehouse> builder)
    {
        throw new NotImplementedException();
    }
}
