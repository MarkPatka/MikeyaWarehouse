using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Warehouse.ValueObjects;

public sealed class StorageSectionId : ValueObject
{
    public int Value { get; }

    private StorageSectionId(int value)
    {
        Value = value;        
    }

    public static StorageSectionId Create(int value)
    {
        return new StorageSectionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
