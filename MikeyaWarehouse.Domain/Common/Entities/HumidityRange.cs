namespace MikeyaWarehouse.Domain.Common.ValueObjects;

public readonly record struct HumidityRange
{
    public double Min { get; init; }
    public double Max { get; init; }
}
