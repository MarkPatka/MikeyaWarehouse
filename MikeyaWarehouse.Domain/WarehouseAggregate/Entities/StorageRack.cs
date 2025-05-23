﻿using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.Entities;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.Entities;

public sealed class StorageRack : Entity<StorageRackId>
{
    private readonly List<StorageSection> _sections = [];
    public IReadOnlyList<StorageSection> StorageSections => _sections.AsReadOnly();

    public int Levels { get; }
    public LoadCapacity LoadCapacity { get; }

    private StorageRack(StorageRackId id,
        int levels, LoadCapacity capacity)
        :base(id)
    {
        Levels = levels;
        LoadCapacity = capacity;
    }

    public static StorageRack Create(
        int id, int levels, LoadCapacity capacity)
    {
        return new(StorageRackId.Create(id), levels, capacity);
    }

}
