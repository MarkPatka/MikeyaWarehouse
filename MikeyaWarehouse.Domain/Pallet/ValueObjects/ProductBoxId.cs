using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Pallet.ValueObjects;

public sealed class ProductBoxId : ValueObject
{
    public int Value { get; }

    private ProductBoxId(int value)
    {
        Value = value;
    }

    public static ProductBoxId Create(int value)
    {
        return new ProductBoxId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;

    }
}
