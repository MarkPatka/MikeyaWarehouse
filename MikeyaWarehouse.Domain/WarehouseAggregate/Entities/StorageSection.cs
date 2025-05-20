using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.Entities;

public sealed class StorageSection : Entity<StorageSectionId>
{
    private readonly List<StorageBin[]> _bins = [];
    public int Shells => _bins.Count;
    public IReadOnlyList<StorageBin[]> StorageBins => _bins.AsReadOnly();

    private StorageSection(StorageSectionId id)
        : base(id)
    { }

    public static StorageSection Create(int id) =>
        new(StorageSectionId.Create(id));
}
