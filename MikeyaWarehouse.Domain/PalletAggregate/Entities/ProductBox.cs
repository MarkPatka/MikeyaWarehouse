using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate.Enumerations;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.PalletAggregate.Entities;

public class ProductBox : Entity<ProductBoxId>
{
    private readonly List<Product> _products = [];
    public IReadOnlyList<Product> Products => _products.AsReadOnly();
    
    public int InBoxProductQuantity => _products.Count;
    public Dimensions Dimensions { get; }
    public DateOnly Expire { get; }
    public DateOnly Production { get; }
    public BarCode Code { get; }
    public BoxStatus BoxStatus { get; private set; } = BoxStatus.FULL;

    private ProductBox()
    {
        

    }

    private ProductBox(
        ProductBoxId id, 
        Dimensions dimensions, 
        DateOnly expire,
        DateOnly production, 
        BarCode code,
        BoxStatus boxStatus) 
        : base(id)
    {
        Dimensions = dimensions;
        Expire = expire;
        Production = production;
        Code = code;
        BoxStatus = boxStatus;
    }

    public static ProductBox Create(
        Dimensions dimensions,
        DateOnly expire,
        DateOnly production,
        BarCode code,
        BoxStatus boxStatus)
    {
        return new(ProductBoxId.Create(Guid.NewGuid()), 
            dimensions, expire, production, code, boxStatus);
    }
}
