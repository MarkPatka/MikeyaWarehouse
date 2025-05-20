using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

public sealed class StorageRackId : ValueObject
{
    public int Value { get; }

    private StorageRackId(int value)
    {
        Value = value;
    }

    public static StorageRackId Create(int id)
    {
        return new StorageRackId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}