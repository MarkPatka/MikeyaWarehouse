using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.ContractorsAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

public class WarehouseAdressId : ValueObject
{
    public int Value { get; }

    private WarehouseAdressId(int value)
    {
        Value = value;
    }

    public static WarehouseAdressId Create(int id)
    {
        return new WarehouseAdressId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
