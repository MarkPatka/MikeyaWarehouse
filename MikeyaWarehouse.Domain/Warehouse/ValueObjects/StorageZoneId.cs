using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Warehouse.ValueObjects;

public sealed class StorageZoneId : ValueObject
{
    public int Value { get; }

    private StorageZoneId(int value)
    {
        Value = value;
    }

    public static StorageZoneId Create(int value)
    {
        return new StorageZoneId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
