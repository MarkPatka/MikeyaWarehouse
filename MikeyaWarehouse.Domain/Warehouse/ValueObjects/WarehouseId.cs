using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Warehouse.ValueObjects;

public sealed class WarehouseId : ValueObject
{
    public int Value { get; }

    private WarehouseId(int value)
    {
        Value = value;
    }
    
    public static WarehouseId Create(int value)
    {
        return new WarehouseId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
