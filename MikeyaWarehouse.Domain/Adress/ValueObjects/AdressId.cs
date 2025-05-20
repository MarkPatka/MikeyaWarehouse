using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Adress.ValueObjects;

public class AdressId : ValueObject
{
    public int Value { get; }

    private AdressId(int value) { Value = value; }

    public static AdressId Create(int value)
    {
        return new AdressId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
