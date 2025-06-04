using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate.Enumerations;
using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.PalletAggregate.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MikeyaWarehouse.Infrastructure.Persistence.Configurations.ModelsConfigurations;

public class PalletsTableConfiguration 
    : IEntityTypeConfiguration<Pallet>
{
    public void Configure(EntityTypeBuilder<Pallet> builder)
    {
        ConfigurePalletTable(builder);
        ConfigureProductBoxTable(builder);
    }

    private static void ConfigurePalletTable(
        EntityTypeBuilder<Pallet> builder)
    {
        builder.ToTable("Pallets");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PalletId.Create(value));

        //builder.Property(x => x.Expires)
        //    .HasConversion(
        //        dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
        //        dateTime => DateOnly.FromDateTime(dateTime));

        builder.Property(x => x.Type)
            .HasConversion(
                new ValueConverter<PalletType, int>(
                type => type.Id,
                value => Enumeration.GetFromId<PalletType>(value)))
            .HasColumnType("integer");

        builder.OwnsOne(x => x.Dimensions, d =>
        {
            d.Property(d => d.Length).HasColumnName("Length");
            d.Property(d => d.Width).HasColumnName("Width");
            d.Property(d => d.Height).HasColumnName("Height");
            d.Property(d => d.Weight).HasColumnName("Weight");
        });
    }

    private static void ConfigureProductBoxTable(
        EntityTypeBuilder<Pallet> builder)
    {
        builder.OwnsMany(x => x.ProductBoxes, pb =>
        {
            pb.ToTable("ProductBoxes");
            pb.WithOwner().HasForeignKey("PalletId");
            pb.HasKey(nameof(ProductBox.Id), "PalletId"); 

            pb.Property(x => x.Id)
                .HasColumnName("ProductBoxId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ProductBoxId.Create(value));

            pb.Property(x => x.BoxStatus)
                .HasConversion(
                    new ValueConverter<BoxStatus, int>(
                    type => type.Id,
                    value => Enumeration.GetFromId<BoxStatus>(value)))
                .HasColumnType("integer");

            pb.Property(x => x.Expire)
                .HasConversion(
                    dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                    dateTime => DateOnly.FromDateTime(dateTime));
            
            pb.Property(x => x.Production)
                .HasConversion(
                    dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                    dateTime => DateOnly.FromDateTime(dateTime));

            pb.OwnsOne(x => x.Dimensions, d =>
            {
                d.Property(d => d.Length).HasColumnName("Length");
                d.Property(d => d.Width).HasColumnName("Width");
                d.Property(d => d.Height).HasColumnName("Height");
                d.Property(d => d.Weight).HasColumnName("Weight");
            });

            pb.OwnsOne(x => x.Code, d =>
            {
                d.Property(d => d.Text).HasColumnName("BarCode");
            });

            pb.OwnsMany(x => x.Products, ptb =>
            {
                ptb.ToTable("Products");

                ptb.WithOwner()
                   .HasForeignKey("ProductBoxId", "PalletId");

                ptb.HasKey(nameof(Product.Id), "ProductBoxId", "PalletId");

                ptb.Property(x => x.Id)
                    .HasColumnName("ProductId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => ProductId.Create(value));

                ptb.Property(x => x.Status)
                    .HasConversion(
                    new ValueConverter<ProductStatus, int>(
                        type => type.Id,
                        value => Enumeration.GetFromId<ProductStatus>(value)))
                    .HasColumnType("integer");

                ptb.Property(p => p.InStock);

                ptb.Property(p => p.Name)
                    .HasMaxLength(100);

                ptb.Property(p => p.Production)
                    .HasConversion(
                        dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                        dateTime => DateOnly.FromDateTime(dateTime));

                ptb.Property(p => p.Expires)
                    .HasConversion(
                        dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                        dateTime => DateOnly.FromDateTime(dateTime));

                ptb.OwnsOne(x => x.BarCode, c =>
                {
                    c.Property(d => d.Text).HasColumnName("BarCode");
                });

                ptb.OwnsOne(x => x.Dimensions, d =>
                {
                    d.Property(d => d.Length).HasColumnName("Length");
                    d.Property(d => d.Width).HasColumnName("Width");
                    d.Property(d => d.Height).HasColumnName("Height");
                    d.Property(d => d.Weight).HasColumnName("Weight");
                });
               
            });

            pb.Navigation(x => x.Products).Metadata
                .SetField("_products");

            pb.Navigation(x => x.Products).Metadata
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        });


        builder.Navigation(x => x.ProductBoxes).Metadata
            .SetField("_boxes");

        builder.Navigation(x => x.ProductBoxes).Metadata
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        //builder.Metadata.FindNavigation(nameof(Pallet.ProductBoxes))!
        //    .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
