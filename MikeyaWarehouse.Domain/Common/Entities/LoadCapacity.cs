namespace MikeyaWarehouse.Domain.Common.ValueObjects;

public readonly record struct LoadCapacity
{
    public double MaxWeight { get; init; }
    public double MaxVolume { get; init; }
}
