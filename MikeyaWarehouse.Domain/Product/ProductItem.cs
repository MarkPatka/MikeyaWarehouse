using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.Product.ValueObjects;

namespace MikeyaWarehouse.Domain.Product;

public sealed class ProductItem : AggregateRoot<ProductItemId>
{
    public string Name { get; }
    public BarCode BarCode { get; }
    public Dimensions Dimensions { get; }
}
