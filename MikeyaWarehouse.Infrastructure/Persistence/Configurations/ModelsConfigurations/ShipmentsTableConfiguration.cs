using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MikeyaWarehouse.Domain.ShipmentAggregate;

namespace MikeyaWarehouse.Infrastructure.Persistence.Configurations.ModelsConfigurations;

public class ShipmentsTableConfiguration
    : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        ConfigureShipmentTable(builder);
    }

    private void ConfigureShipmentTable(
        EntityTypeBuilder<Shipment> builder)
    {

    }
}
