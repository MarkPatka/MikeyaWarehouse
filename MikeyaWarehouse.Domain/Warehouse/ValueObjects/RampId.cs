using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Warehouse.ValueObjects;

public sealed class RampId : ValueObject
{
    public int Value { get; }

    private RampId(int value)
    {
        Value = value;
    }

    public static RampId Create(int id)
    {
        return new RampId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
