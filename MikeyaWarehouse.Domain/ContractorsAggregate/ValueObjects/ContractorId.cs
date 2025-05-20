using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.ProductAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.ContractorsAggregate.ValueObjects;

public sealed class ContractorId : ValueObject
{
    public int Value { get; }

    private ContractorId(int value)
    {
        Value = value;
    }

    public static ContractorId Create(int value)
    {
        return new ContractorId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
