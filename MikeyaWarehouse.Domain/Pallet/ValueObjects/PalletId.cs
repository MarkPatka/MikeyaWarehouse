using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Product.ValueObjects;

public sealed class PalletId : ValueObject
{
    public int Value { get; }

    private PalletId(int value)
    {
        Value = value;
    }

    public static PalletId Create(int value)
    {
        return new PalletId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
