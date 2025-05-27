using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;
using MikeyaWarehouse.Domain.WarehouseAggregate.Entities;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate;

public sealed class Warehouse : AggregateRoot<WarehouseId>
{
    private readonly List<BufferZone> _buffers = [];
    private readonly List<StorageZone> _storages = [];
    private readonly List<Ramp> _ramps = [];
    private readonly List<PalletId> _palletIds = [];

    public IReadOnlyList<BufferZone> BufferZones => _buffers.AsReadOnly();
    public IReadOnlyList<StorageZone> StorageZones => _storages.AsReadOnly();
    public IReadOnlyList<Ramp> Ramps => _ramps.AsReadOnly();
    public IReadOnlyList<PalletId> PalletIds => _palletIds.AsReadOnly();

    public string Name { get; } = null!;
    public WarehouseAdress Adress { get; }

#pragma warning disable CS8618
    private Warehouse() { }
#pragma warning restore CS8618

    private Warehouse(WarehouseId id, string name, WarehouseAdress location)
        : base(id) => (Adress, Name) = (location, name);

    public static Warehouse Create(int id, string name, WarehouseAdress location) =>
        new(WarehouseId.Create(id), name, location);
}
