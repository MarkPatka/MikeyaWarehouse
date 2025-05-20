using MikeyaWarehouse.Domain.Adress.Entities;
using MikeyaWarehouse.Domain.Adress.ValueObjects;
using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Adress;

public sealed class Adress : Entity<AdressId>
{
    public string Street { get; } = null!;
    public string City { get; } = null!;
    public string State { get; } = null!;
    public string Country { get; } = null!;
    public string PostalCode { get; } = null!;
    public GeoCoordinates? Coordinates { get; }

    private Adress(
        AdressId adressId,
        string street, 
        string city, 
        string state, 
        string country, 
        string postalCode, 
        GeoCoordinates? coordinates)
        : base(adressId)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
        Coordinates = coordinates;
    }

    public static Adress Create(
        int id,
        string street,
        string city,
        string state,
        string country,
        string postalCode,
        GeoCoordinates? coordinates)
    {
        return new(AdressId.Create(id),
            street, city, state, country, postalCode, coordinates);
    }

}
