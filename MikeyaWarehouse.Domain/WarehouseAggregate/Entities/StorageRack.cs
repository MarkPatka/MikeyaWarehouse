using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.Entities;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.Entities;

public sealed class StorageRack : Entity<StorageRackId>
{
    private readonly List<StorageSection> _sections = [];
    public IReadOnlyList<StorageSection> StorageSections => _sections.AsReadOnly();

    public int Levels { get; }
    public LoadCapacity LoadCapacity { get; }

#pragma warning disable CS8618
    private StorageRack() { }
#pragma warning restore CS8618

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
