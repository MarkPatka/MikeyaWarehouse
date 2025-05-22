namespace MikeyaWarehouse.Domain.Common.Entities;

public record Adress(
    int Id,
    string Street,
    string City,
    string State,
    string Country,
    string PostalCode,
    GeoCoordinates? Coordinates);