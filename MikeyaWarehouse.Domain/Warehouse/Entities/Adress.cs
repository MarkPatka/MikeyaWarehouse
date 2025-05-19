using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Warehouse.ValueObjects;

namespace MikeyaWarehouse.Domain.Warehouse.Entities;

public sealed class Adress : Entity<AdressId>
{
    public string Street { get; } = null!;
    public string City { get; } = null!;
    public string State { get; } = null!;
    public string Country { get; } = null!;
    public string PostalCode { get; } = null!;
    public GeoCoordinates? Coordinates { get; }

}
