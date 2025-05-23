using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.Entities;
using MikeyaWarehouse.Domain.ContractorsAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.ContractorsAggregate.Entities;

public class ContractorAdress : Entity<ContractorAdressId>
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }
    public string PostalCode { get; }
    public GeoCoordinates? Coordinates { get; }

    private ContractorAdress(
        ContractorAdressId id,
        string street,
        string city,
        string state,
        string country,
        string postalCode,
        GeoCoordinates? coordinates)
        : base(id)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
        Coordinates = coordinates;
    }

    public static ContractorAdress Create(
        int id,
        string street,
        string city,
        string state,
        string country,
        string postalCode,
        GeoCoordinates? coordinates)
    {
        return new(ContractorAdressId.Create(id), 
            street, city, state, country, postalCode, coordinates);
    }
}
