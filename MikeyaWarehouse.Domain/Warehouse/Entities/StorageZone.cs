using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Warehouse.ValueObjects;

namespace MikeyaWarehouse.Domain.Warehouse.Entities;

public sealed class StorageZone : Entity<StorageZoneId>
{
    private readonly List<StorageRack> _racks = [];

    public string Code { get; } // A, B, C, D ...
    public ClimatRegime Regime { get; } 



}
