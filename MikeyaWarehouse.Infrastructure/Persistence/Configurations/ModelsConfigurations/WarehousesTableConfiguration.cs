using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.WarehouseAggregate;
using MikeyaWarehouse.Domain.WarehouseAggregate.Entities;
using MikeyaWarehouse.Domain.WarehouseAggregate.Enumerations;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Infrastructure.Persistence.Configurations.ModelsConfigurations;

public class WarehousesTableConfiguration
    : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        ConfigureWarehouseTable(builder);
        ConfigureWarehouseAdressesTable(builder);
        ConfigureBufferZonesTable(builder);
        ConfigureRampsTable(builder);
        ConfigureStorageZonesTable(builder);
    }

    private static void ConfigureWarehouseTable(
        EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("Warehouses");

        builder.HasKey(w => w.Id);

        builder.Property(x => x.Id)
            .HasColumnName("WarehouseId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => WarehouseId.Create(value));

        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.OwnsMany(x => x.PalletIds, b =>
        {
            b.ToTable("WarehousePalletIds");

            b.WithOwner().HasForeignKey("WarehouseId");

            b.HasKey("Id");

            b.Property(x => x.Value)
                .HasColumnName("PalletId")
                .ValueGeneratedNever();
        });
        builder.Metadata.FindNavigation(nameof(Warehouse.PalletIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureWarehouseAdressesTable(
        EntityTypeBuilder<Warehouse> builder)
    {
        builder.OwnsOne(x => x.Adress, ab =>
        {
            ab.ToTable("WarehouseAdresses");

            ab.HasKey(x => x.Id);

            ab.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => WarehouseAdressId.Create(value));

            ab.Property(x => x.Street)
                .HasMaxLength(100);

            ab.Property(x => x.City)
                .HasMaxLength(100);

            ab.Property(x => x.State)
                .HasMaxLength(100);

            ab.Property(x => x.PostalCode)
                .HasMaxLength(20);
        });
    }
    
    private static void ConfigureStorageZonesTable(
        EntityTypeBuilder<Warehouse> builder)
    {
        builder.OwnsMany(x => x.StorageZones, szb =>
        {
            szb.ToTable("StorageZones");
            szb.WithOwner().HasForeignKey("WarehouseId");

            szb.HasKey(nameof(StorageZone.Id), "WarehouseId");
            
            szb.Property(x => x.Id)
                .HasColumnName("StorageZoneId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => StorageZoneId.Create(value));

            szb.OwnsOne(x => x.Regime, rb =>
            {
                rb.OwnsOne(t => t.TemperatureRange, trb =>
                {
                    trb.Property(x => x.Min).HasColumnName("MinTemperatureRegime");
                    trb.Property(x => x.Max).HasColumnName("MaxTemperatureRegime");
                });
                rb.OwnsOne(t => t.HumidityRange, hrb =>
                {
                    hrb.Property(x => x.Min).HasColumnName("MinHumidityRegime");
                    hrb.Property(x => x.Max).HasColumnName("MaxHumidityRegime");
                });
            });

            szb.Property(x => x.Code)
                .HasColumnType("char(1)")
                .IsFixedLength();

            szb.OwnsMany(x => x.StorageRacks, rb =>
            {
                rb.ToTable("WarehouseRacks");
                
                rb.WithOwner().HasForeignKey("StorageZoneId", "WarehouseId");
                
                rb.HasKey(nameof(StorageRack.Id), "StorageZoneId", "WarehouseId");

                rb.Property(x => x.Id)
                    .HasColumnName("StorageRackId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => StorageRackId.Create(value));

                rb.OwnsOne(x => x.LoadCapacity, lb =>
                {
                    lb.Property(p => p.MaxVolume);
                    lb.Property(p => p.MaxWeight);
                });

                rb.OwnsMany(x => x.StorageSections, sb =>
                {
                    sb.ToTable("RackSections");
                    sb.WithOwner().HasForeignKey("StorageRackId", "StorageZoneId", "WarehouseId");

                    sb.HasKey(nameof(StorageSection.Id), "StorageRackId", "StorageZoneId", "WarehouseId");

                    sb.Property(x => x.Id)
                        .HasColumnName("StorageSectionId")
                        .ValueGeneratedNever()
                        .HasConversion(
                            id => id.Value,
                            value => StorageSectionId.Create(value));


                    sb.OwnsMany(x => x.StorageBins, sbb =>
                    {
                        sbb.ToTable("SectionBins");
                        sbb.WithOwner().HasForeignKey("StorageSectionId", "StorageRackId", "StorageZoneId", "WarehouseId");

                        sbb.HasKey(nameof(StorageBin.Id), "StorageSectionId", "StorageRackId", "StorageZoneId", "WarehouseId");

                        sbb.Property(x => x.Id)
                            .HasColumnName("StorageBinId")
                            .ValueGeneratedNever()
                            .HasConversion(
                                id => id.Value,
                                value => StorageBinId.Create(value));

                        sbb.OwnsOne(x => x.BinBarCode, bc =>
                        {
                            bc.Property(c => c.Text).HasColumnName("BinBarCode");
                        });

                        sbb.Property(x => x.Status)
                            .HasConversion(
                                i => i.Id,
                                v => Enumeration.GetFromId<StorageBinStatus>(v));

                        sbb.OwnsOne(x => x.Dimensions, d =>
                        {
                            d.Property(d => d.Length).HasColumnName("Length");
                            d.Property(d => d.Width).HasColumnName("Width");
                            d.Property(d => d.Height).HasColumnName("Height");
                            d.Property(d => d.Weight).HasColumnName("Weight");
                        });

                        sbb.OwnsOne(x => x.LoadCapacity, lb =>
                        {
                            lb.Property(p => p.MaxVolume);
                            lb.Property(p => p.MaxWeight);
                        });

                        sbb.OwnsOne(x => x.StoredPalletId, pid =>
                        {
                            pid.ToTable("StorageBinPallets");

                            pid.WithOwner().HasForeignKey(
                                "StorageBinId", "StorageSectionId", "StorageRackId", "StorageZoneId", "WarehouseId");

                            pid.Property<int>("Id");
                            pid.HasKey("Id");

                            pid.Property(d => d.Value)
                                .HasColumnName("PalletId")
                                .ValueGeneratedNever();
                        });
                        sbb.Navigation(x => x.StoredPalletId).IsRequired(false);

                        sbb.OwnsMany(x => x.StoredBoxes, b =>
                        {
                            b.ToTable("StorageBinBoxes");

                            b.WithOwner().HasForeignKey(
                                "StorageBinId", "StorageSectionId", "StorageRackId", "StorageZoneId", "WarehouseId");
                            
                            b.Property<int>("Id");
                            b.HasKey("Id");

                            b.Property(x => x.Value)
                                .HasColumnName("BoxId")
                                .ValueGeneratedNever();
                        });

                        sbb.Navigation(x => x.StoredBoxes).Metadata
                            .SetField("_storedBoxes");

                        sbb.Navigation(x => x.StoredBoxes)
                            .UsePropertyAccessMode(PropertyAccessMode.Field);
                    });

                    sb.Navigation(x => x.StorageBins).Metadata
                        .SetField("_bins");

                    sb.Navigation(x => x.StorageBins)
                        .UsePropertyAccessMode(PropertyAccessMode.Field);
                });

                rb.Navigation(x => x.StorageSections).Metadata
                    .SetField("_sections");

                rb.Navigation(x => x.StorageSections)
                    .UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            szb.Navigation(s => s.StorageRacks).Metadata
                .SetField("_racks");

            szb.Navigation(s => s.StorageRacks)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Navigation(x => x.StorageZones).Metadata
            .SetField("_storages");

        builder.Navigation(x => x.StorageZones).Metadata
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        //builder.Metadata.FindNavigation(nameof(Warehouse.StorageZones))!
        //    .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureRampsTable(
        EntityTypeBuilder<Warehouse> builder)
    {
        builder.OwnsMany(x => x.Ramps, rb =>
        {
            rb.ToTable("WarehouseRamps");

            rb.WithOwner().HasForeignKey("WarehouseId");

            rb.HasKey(nameof(Ramp.Id), "WarehouseId");

            rb.Property(x => x.Id)
                .HasColumnName("RampId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => RampId.Create(value));

            rb.Property(x => x.Gate)
                .HasColumnType("char(1)")
                .IsFixedLength();

            rb.Property(x => x.Status)
                .HasConversion(
                    i => i.Id,
                    v => Enumeration.GetFromId<RampStatus>(v));
        });
        builder.Metadata.FindNavigation(nameof(Warehouse.Ramps))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureBufferZonesTable(
        EntityTypeBuilder<Warehouse> builder)
    {
        builder.OwnsMany(x => x.BufferZones, bzb =>
        {
            bzb.ToTable("WarehouseBufferZones");

            bzb.WithOwner().HasForeignKey("WarehouseId");

            bzb.HasKey(nameof(BufferZone.Id), "WarehouseId");

            bzb.Property(x => x.Id)
                .HasColumnName("BufferZoneId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => BufferZoneId.Create(value));
            
            bzb.OwnsOne(x => x.LoadCapacity, lb =>
            {
                lb.Property(p => p.MaxVolume);
                lb.Property(p => p.MaxWeight);
            });

            bzb.OwnsOne(x => x.Dimensions, d =>
            {
                d.Property(d => d.Length).HasColumnName("Length");
                d.Property(d => d.Width).HasColumnName("Width");
                d.Property(d => d.Height).HasColumnName("Height");
                d.Property(d => d.Weight).HasColumnName("Weight");
            });

            bzb.Property(x => x.Status)
                .HasConversion(
                    i => i.Id,
                    v => Enumeration.GetFromId<BufferZoneStatus>(v));
        });


        builder.Navigation(x => x.BufferZones).Metadata
            .SetField("_buffers");

        builder.Navigation(x => x.BufferZones).Metadata
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        //builder.Metadata.FindNavigation(nameof(Warehouse.BufferZones))!
        //    .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
