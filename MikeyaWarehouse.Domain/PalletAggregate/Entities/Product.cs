using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate.Enumerations;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.PalletAggregate.Entities;

public sealed class Product : Entity<ProductId>
{
    public string Name { get; } = null!;
    public int InStock { get; }
    public DateOnly Production { get; }
    public DateOnly Expires { get; }
    public BarCode BarCode { get; }
    public Dimensions Dimensions { get; }
    public ProductStatus Status { get; private set; } = ProductStatus.IN_STOCK;


#pragma warning disable CS8618
    private Product() { }
#pragma warning restore CS8618

    private Product(ProductId id, 
        string name, int inStock, DateOnly production, DateOnly expires, 
        BarCode code, Dimensions dimensions, ProductStatus status)
        : base(id)
    {
        Name = name;
        InStock = inStock;
        Production = production;
        Expires = expires;
        BarCode = code;
        Dimensions = dimensions;
        Status = status;
    }

    public static Product Create(
        int id, string name, int inStock, DateOnly production, DateOnly expires,
        BarCode code, Dimensions dimensions, ProductStatus status)
    {
        return new(ProductId.Create(id), 
            name, inStock, production, expires, code, dimensions, status);
    }
}
