using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;

public sealed class PalletId : ValueObject
{
    public Guid Value { get; }

    private PalletId(Guid value)
    {
        Value = value;
    }

    public static PalletId Create(Guid value)
    {
        return new PalletId(value);
    }
    public static PalletId CreateUnic()
    {
        return new PalletId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
