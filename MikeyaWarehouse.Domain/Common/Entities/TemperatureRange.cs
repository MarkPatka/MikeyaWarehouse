namespace MikeyaWarehouse.Domain.Common.ValueObjects;

public readonly record struct TemperatureRange
{
    public double Min { get; init; } 
    public double Max { get; init; }
}
