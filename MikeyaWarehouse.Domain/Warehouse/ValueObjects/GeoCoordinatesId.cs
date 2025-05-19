using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Warehouse.ValueObjects;

public sealed class GeoCoordinatesId : ValueObject
{
    public int Value { get; }

    private GeoCoordinatesId(int value)
    {
        Value = value;
    }

    public static GeoCoordinatesId Create(int value)
    {
        return new GeoCoordinatesId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
