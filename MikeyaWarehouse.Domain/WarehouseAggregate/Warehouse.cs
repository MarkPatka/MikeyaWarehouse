using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.Entities;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;
using MikeyaWarehouse.Domain.ProductAggregate.ValueObjects;
using MikeyaWarehouse.Domain.ShipmentAggregate.ValueObjects;
using MikeyaWarehouse.Domain.WarehouseAggregate.Entities;
using MikeyaWarehouse.Domain.WarehouseAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.WarehouseAggregate;

public sealed class Warehouse : AggregateRoot<WarehouseId>
{
    private readonly List<BufferZone> _buffers = [];
    private readonly List<StorageZone> _storages = [];
    private readonly List<Ramp> _ramps = [];

    private readonly List<ProductId> _productIds = [];
    private readonly List<PalletId> _palletIds = [];
    private readonly List<ShipmentId> _shipmentIds = [];

    public IReadOnlyList<BufferZone> Buffers => _buffers.AsReadOnly();
    public IReadOnlyList<StorageZone> Storages => _storages.AsReadOnly();
    public IReadOnlyList<Ramp> Ramps => _ramps.AsReadOnly();

    public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();
    public IReadOnlyList<PalletId> PalletIds => _palletIds.AsReadOnly();
    public IReadOnlyList<ShipmentId> ShipmentIds => _shipmentIds.AsReadOnly();

    public Adress Location { get; }
    public string Name { get; } = null!;

    private Warehouse(WarehouseId id, string name, Adress location)
        : base(id) => (Location, Name) = (location, name);

    public static Warehouse Create(int id, string name, Adress location) =>
        new(WarehouseId.Create(id), name, location);
}
