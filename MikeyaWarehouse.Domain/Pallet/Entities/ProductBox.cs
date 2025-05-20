using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.Pallet.ValueObjects;
using MikeyaWarehouse.Domain.Product.ValueObjects;

namespace MikeyaWarehouse.Domain.Pallet.Entities;

public class ProductBox : Entity<ProductBoxId>
{
    public ProductId BoxedProductId { get; }
    public int ProductQuantity { get; }
    public Dimensions Dimensions { get; }
    public DateTime Expire { get; }
    public DateTime Production { get; }
    public BarCode Code { get; }

    private ProductBox(
        ProductBoxId id, 
        ProductId productId,
        int productQuantity,
        Dimensions dimensions, 
        DateTime expire, 
        DateTime production, 
        BarCode code) 
        : base(id)
    {
        BoxedProductId = productId;
        ProductQuantity = productQuantity;
        Dimensions = dimensions;
        Expire = expire;
        Production = production;
        Code = code;
    }

    public static ProductBox Create(int id, 
        ProductId productId,
        int productQuantity,
        Dimensions dimensions,
        DateTime expire,
        DateTime production,
        BarCode code)
    {
        return new(ProductBoxId.Create(id), 
            productId, productQuantity, dimensions, expire, production, code);
    }
}
