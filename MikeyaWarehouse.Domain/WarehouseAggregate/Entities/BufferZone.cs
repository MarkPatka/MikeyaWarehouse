using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.WarehouseAggregate.Enumerations;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.Entities;

public sealed class BufferZone : Entity<BufferZoneId>
{
    public LoadCapacity LoadCapacity { get; }
    public Dimensions Dimensions { get; }
    public BufferZoneStatus Status { get; } = BufferZoneStatus.EMPTY;

    private BufferZone(
        BufferZoneId id,
        LoadCapacity loadCapacity,
        Dimensions dimensions,
        BufferZoneStatus status)
        : base(id)
    {
        LoadCapacity = loadCapacity;
        Dimensions = dimensions;
        Status = status;
    }

    public static BufferZone Create(
        int id,
        LoadCapacity loadCapacity,
        Dimensions dimensions,
        BufferZoneStatus status)
    {
        return new(BufferZoneId.Create(id),
            loadCapacity, dimensions, status);
    }
}
