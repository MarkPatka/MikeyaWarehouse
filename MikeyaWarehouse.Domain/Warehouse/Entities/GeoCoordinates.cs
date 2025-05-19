using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Warehouse.ValueObjects;

namespace MikeyaWarehouse.Domain.Warehouse.Entities;

public sealed class GeoCoordinates : Entity<GeoCoordinatesId>
{
    public double Latitude { get; }
    public double Longitude { get; }
}
