using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Warehouse.ValueObjects;

public sealed class StorageBinId : ValueObject
{
    public int Value { get; }

    private StorageBinId(int value) 
    {
        Value = value;
    }

    public static StorageBinId Create(int value)
    {
        return new StorageBinId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
