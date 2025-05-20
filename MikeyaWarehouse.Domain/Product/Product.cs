using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.Product.ValueObjects;

namespace MikeyaWarehouse.Domain.Product;

public sealed class Product : AggregateRoot<ProductId>
{
    public string Name { get; } = null!;
    public DateTime Production { get; }
    public DateTime Expires { get; }
    public BarCode BarCode { get; }
    public Dimensions Dimensions { get; }

    private Product(ProductId id, 
        string name, DateTime production, DateTime expires, 
        BarCode code, Dimensions dimensions)
        : base(id)
    {
        Name = name;
        Production = production;
        Expires = expires;
        BarCode = code;
        Dimensions = dimensions;
    }

    public static Product Create(
        int id, string name, DateTime production, DateTime expires,
        BarCode code, Dimensions dimensions)
    {
        return new(ProductId.Create(id), name, production, expires, code, dimensions);
    }
}
