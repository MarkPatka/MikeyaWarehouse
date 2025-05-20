using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;

public sealed class ProductBoxId : ValueObject
{
    public Guid Value { get; }

    private ProductBoxId(Guid value)
    {
        Value = value;
    }
    public static ProductBoxId Create(Guid value)
    {
        return new ProductBoxId(value);
    }
    public static ProductBoxId CreateUnic()
    {
        return new ProductBoxId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
