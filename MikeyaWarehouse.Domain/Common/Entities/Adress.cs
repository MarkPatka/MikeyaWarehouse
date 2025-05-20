namespace MikeyaWarehouse.Domain.Common.Entities;

public readonly record struct Adress
{
    public string Street { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Country { get; init; }
    public string PostalCode { get; init; }
    public GeoCoordinates? Coordinates { get; init; }
}