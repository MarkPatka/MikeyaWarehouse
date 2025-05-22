using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MikeyaWarehouse.Domain.ContractorsAggregate;
using MikeyaWarehouse.Domain.ContractorsAggregate.ValueObjects;

namespace MikeyaWarehouse.Infrastructure.Persistence.Configurations.ModelsConfigurations;

public class ContractorsTableConfiguration
    : IEntityTypeConfiguration<Contractor>
{
    public void Configure(EntityTypeBuilder<Contractor> builder)
    {
        ConfigureContractorsTable(builder);
    }

    private void ConfigureContractorsTable(
        EntityTypeBuilder<Contractor> builder)
    {
        builder.ToTable("Contractors");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ContractorId.Create(value));

        builder.Property<string>(x => x.Name)
            .HasMaxLength(256);

        //builder.OwnsOne(x => x.Adress);
        //builder.OwnsMany(x => x.ShipmentIds);
    }
}
