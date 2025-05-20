namespace MikeyaWarehouse.Domain.Common.Entities;

public readonly record struct GeoCoordinates
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }
}
