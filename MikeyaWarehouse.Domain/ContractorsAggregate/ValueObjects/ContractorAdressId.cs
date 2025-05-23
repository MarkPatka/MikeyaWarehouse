using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.ContractorsAggregate.ValueObjects;

public class ContractorAdressId : ValueObject
{
    public int Value { get; }

    private ContractorAdressId(int value)
    {
        Value = value;
    }

    public static ContractorAdressId Create(int id)
    {
        return new ContractorAdressId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
