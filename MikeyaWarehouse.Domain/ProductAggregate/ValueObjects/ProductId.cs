
using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.ProductAggregate.ValueObjects;

public sealed class ProductId : ValueObject
{
    public int Value { get; }

    private ProductId(int value)
    {
        Value = value;
    }

    public static ProductId Create(int value)
    {
        return new ProductId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
