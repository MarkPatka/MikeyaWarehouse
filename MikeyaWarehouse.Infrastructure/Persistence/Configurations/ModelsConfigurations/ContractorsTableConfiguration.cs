using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.ContractorsAggregate;
using MikeyaWarehouse.Domain.ContractorsAggregate.Entities;
using MikeyaWarehouse.Domain.ContractorsAggregate.Enumerations;
using MikeyaWarehouse.Domain.ContractorsAggregate.ValueObjects;

namespace MikeyaWarehouse.Infrastructure.Persistence.Configurations.ModelsConfigurations;

public class ContractorsTableConfiguration
    : IEntityTypeConfiguration<Contractor>
{
    public void Configure(EntityTypeBuilder<Contractor> builder)
    {
        ConfigureContractorsTable(builder);
        ConfigureShipmentsTable(builder);
        ConfigureContractorsAdressesTable(builder);
    }

    private static void ConfigureContractorsTable(
        EntityTypeBuilder<Contractor> builder)
    {
        builder.ToTable("Contractors");

        builder.HasKey(nameof(Contractor.Id));

        builder.Property(x => x.Id)
            .HasColumnName("ContractorId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ContractorId.Create(value));

        builder.Property(x => x.Name)
            .HasMaxLength(100);
        
        builder.Metadata.FindNavigation(nameof(Contractor.Shipments))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureShipmentsTable(
        EntityTypeBuilder<Contractor> builder)
    {
        builder.OwnsMany(x => x.Shipments, sb =>
        {
            sb.ToTable("Shipments");
            sb.WithOwner().HasForeignKey("ContractorId");
            sb.HasKey(nameof(Shipment.Id), "ContractorId");

            sb.Property(x => x.Id)
                .HasColumnName("ShipmentId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ShipmentId.Create(value));

            sb.Property(x => x.Type)
                .HasConversion(
                    i => i.Id,
                    v => Enumeration.GetFromId<ShipmentType>(v));

            sb.Property(x => x.Status)
                .HasConversion(
                    i => i.Id,
                    v => Enumeration.GetFromId<ShipmentStatus>(v));

            sb.OwnsMany(x => x.PalletIds, pid =>
            {
                pid.ToTable("ShipmentPalletIds");

                pid.WithOwner().HasForeignKey("ShipmentId", "ContractorId");

                pid.HasKey("Id");

                pid.Property(p => p.Value)
                    .HasColumnName("PalletId")
                    .ValueGeneratedNever();
            });
           
            sb.Navigation(s => s.PalletIds).Metadata
                .SetField("_pallets");
            
            sb.Navigation(s => s.PalletIds)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        });
    }

    private static void ConfigureContractorsAdressesTable(
        EntityTypeBuilder<Contractor> builder)
    {
        builder.OwnsOne(x => x.Adress, ab =>
        {
            ab.ToTable("ContractorsAdresses");
            ab.WithOwner().HasForeignKey("ContractorId");
            ab.HasKey(nameof(ContractorAdress.Id), "ContractorId");

            ab.Property(x => x.Id)
                .HasColumnName("ContractorAdressId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ContractorAdressId.Create(value));

            ab.Property(x => x.Street)
                .HasMaxLength(100);

            ab.Property(x => x.City)
                .HasMaxLength(100);

            ab.Property(x => x.State)
                .HasMaxLength(100);

            ab.Property(x => x.PostalCode)
                .HasMaxLength(20);

            ab.OwnsOne(x => x.Coordinates, c =>
            {
                c.Property(d => d.Latitude).HasColumnName("Latitude");
                c.Property(d => d.Longitude).HasColumnName("Longitude");
            });

            ab.Navigation(o => o.Coordinates).IsRequired(false);
        });
    }

}
