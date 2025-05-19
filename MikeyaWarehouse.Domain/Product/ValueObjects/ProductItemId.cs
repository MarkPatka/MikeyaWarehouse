
using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Product.ValueObjects;

public sealed class ProductItemId : ValueObject
{
    public int Value { get; }

    public ProductItemId(int value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
