using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;
using MikeyaWarehouse.Domain.ProductAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.PalletAggregate.Entities;

public class ProductBox : Entity<ProductBoxId>
{
    public ProductId BoxedProductId { get; }
    public int Quantity { get; }
    public Dimensions Dimensions { get; }
    public DateOnly Expire { get; }
    public DateOnly Production { get; }
    public BarCode Code { get; }

    private ProductBox(
        ProductBoxId id, 
        ProductId productId,
        int productQuantity,
        Dimensions dimensions, 
        DateOnly expire,
        DateOnly production, 
        BarCode code) 
        : base(id)
    {
        BoxedProductId = productId;
        Quantity = productQuantity;
        Dimensions = dimensions;
        Expire = expire;
        Production = production;
        Code = code;
    }

    public static ProductBox Create(
        ProductId productId,
        int productQuantity,
        Dimensions dimensions,
        DateOnly expire,
        DateOnly production,
        BarCode code)
    {
        return new(ProductBoxId.Create(Guid.NewGuid()), 
            productId, productQuantity, dimensions, expire, production, code);
    }
}
