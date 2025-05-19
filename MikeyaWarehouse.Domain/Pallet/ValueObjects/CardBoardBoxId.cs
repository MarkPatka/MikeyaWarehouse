using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;

namespace MikeyaWarehouse.Domain.Pallet.ValueObjects;

public sealed class CardBoardBoxId : ValueObject
{
    public int Value { get; }

    private CardBoardBoxId(int value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;

    }
}
