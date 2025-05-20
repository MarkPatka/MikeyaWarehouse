using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

public sealed class BufferZoneId : ValueObject
{
    public int Value { get; }

    private BufferZoneId(int value) { Value = value; }

    public static BufferZoneId Create(int value)
    {
        return new BufferZoneId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
