using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.ContractorsAggregate.ValueObjects;

public sealed class ShipmentId : ValueObject
{
    public Guid Value { get; }

    private ShipmentId(Guid value)
    {
        Value = value;
    }
    public static ShipmentId Create(Guid value)
    {
        return new ShipmentId(value);
    }
    public static ShipmentId CreateNew()
    {
        return new ShipmentId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
