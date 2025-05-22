using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate.Enumerations;
using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Infrastructure.Persistence.Configurations.ModelsConfigurations;

public class PalletsTableConfiguration 
    : IEntityTypeConfiguration<Pallet>
{
    public void Configure(EntityTypeBuilder<Pallet> builder)
    {
        ConfigurePalletTable(builder);
        ConfigureProductBoxTable(builder);
    }

    private void ConfigureProductBoxTable(
        EntityTypeBuilder<Pallet> builder)
    {
        builder.OwnsMany(x => x.ProductBoxes, pb =>
        {
            pb.ToTable("ProductBoxes");
            pb.WithOwner().HasForeignKey("PalletId");
            pb.HasKey("Id"); 

            pb.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ProductBoxId.Create(value));

            pb.Property(x => x.Quantity);

            pb.OwnsOne(x => x.Dimensions, d =>
            {
                d.Property(d => d.Length).HasColumnName("Length");
                d.Property(d => d.Width).HasColumnName("Width");
                d.Property(d => d.Height).HasColumnName("Height");
                d.Property(d => d.Weight).HasColumnName("Weight");
            });

            pb.Property(x => x.Expire)
            .HasConversion(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime));
            
            pb.Property(x => x.Production)
            .HasConversion(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime));

            pb.OwnsOne(x => x.Code, d =>
            {
                d.Property(d => d.Text).HasColumnName("BarCode");
            });
        });
    }

    private void ConfigurePalletTable(
        EntityTypeBuilder<Pallet> builder)
    {
        builder.ToTable("Pallets");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PalletId.Create(value));

        builder.Property(x => x.Expires)
            .HasConversion(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime));

        builder.Property(x => x.Type)
            .HasConversion(
                type => type.Id,
                value => Enumeration.GetFromId<PalletType>(value));


        builder.OwnsOne(x => x.Dimensions, d =>
        {
            d.Property(d => d.Length).HasColumnName("Length");
            d.Property(d => d.Width).HasColumnName("Width");
            d.Property(d => d.Height).HasColumnName("Height");
            d.Property(d => d.Weight).HasColumnName("Weight");
        });
    }
}
