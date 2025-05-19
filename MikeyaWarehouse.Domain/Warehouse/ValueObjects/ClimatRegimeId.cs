using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Warehouse.ValueObjects;

public sealed class ClimatRegimeId : ValueObject
{
    public int Value { get; }

    private ClimatRegimeId(int value)
    {
        Value = value;
    }

    public static ClimatRegimeId Create(int value)
    {
        return new ClimatRegimeId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
