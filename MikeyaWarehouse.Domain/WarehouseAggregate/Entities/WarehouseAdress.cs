using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.Entities;

public class WarehouseAdress: Entity<WarehouseAdressId>
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }
    public string PostalCode { get; }

    private WarehouseAdress()
    {
        
    }

    private WarehouseAdress(
        WarehouseAdressId id,
        string street,
        string city,
        string state,
        string country,
        string postalCode)
        : base(id)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
    }

    public static WarehouseAdress Create(
        int id,
        string street,
        string city,
        string state,
        string country,
        string postalCode)
    {
        return new(WarehouseAdressId.Create(id),
            street, city, state, country, postalCode);
    }
}
