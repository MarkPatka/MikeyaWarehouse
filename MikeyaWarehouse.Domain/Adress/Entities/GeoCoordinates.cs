using MikeyaWarehouse.Domain.Adress.ValueObjects;
using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Adress.Entities;

public sealed class GeoCoordinates : Entity<GeoCoordinatesId>
{
    public double Latitude { get; }
    public double Longitude { get; }

    private GeoCoordinates(
        GeoCoordinatesId id,
        double latitude,
        double longtitude)
        : base(id)
    {
        Latitude = latitude;
        Longitude = longtitude;
    }

    public static GeoCoordinates Create(
        int id,
        double latitude,
        double longtitude)
    {
        return new(GeoCoordinatesId.Create(id), latitude, longtitude);
    }
}
