﻿using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.Entities;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.Entities;

public sealed class StorageZone : Entity<StorageZoneId>
{
    private readonly List<StorageRack> _racks = [];
    public IReadOnlyList<StorageRack> StorageRacks => _racks.AsReadOnly();

    public ClimatRegime Regime { get; }
    public char Code { get; }

    private StorageZone(
        StorageZoneId id, 
        ClimatRegime regime, 
        char code) 
        : base(id)
    {
        Regime = regime;
        Code = code;
    }

    public static StorageZone Create(
        int id, ClimatRegime regime, char code)
    {
        return new(StorageZoneId.Create(id), regime, code);
    }

}
