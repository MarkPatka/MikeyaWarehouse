using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.Warehouse.ValueObjects;

namespace MikeyaWarehouse.Domain.Warehouse.Entities;

public sealed class StorageRack : Entity<StorageRackId>
{
    private readonly List<StorageSection> _sections = [];

    public int Levels { get; }
    public LoadCapacity LoadCapacity { get; }
    public IReadOnlyList<StorageSection> Sections => _sections.AsReadOnly();


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
