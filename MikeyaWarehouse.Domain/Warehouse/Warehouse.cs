using MikeyaWarehouse.Domain.Adress.ValueObjects;
using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Delivery.ValueObjects;
using MikeyaWarehouse.Domain.OutcomingDelivery.ValueObjects;
using MikeyaWarehouse.Domain.Product.ValueObjects;
using MikeyaWarehouse.Domain.Warehouse.Entities;
using MikeyaWarehouse.Domain.Warehouse.ValueObjects;

namespace MikeyaWarehouse.Domain.Warehouse;

public sealed class Warehouse : AggregateRoot<WarehouseId>
{
    private readonly List<BufferZone> _buffers = [];
    private readonly List<StorageZone> _storages = [];
    private readonly List<Ramp> _ramps = [];

    private readonly List<ProductId> _productIds = [];
    private readonly List<PalletId> _palletIds = [];
    private readonly List<DeliveryInId> _deliveryInIds = [];
    private readonly List<DeliveryOutId> _deliveryOutIds = [];

    public IReadOnlyList<BufferZone> Buffers => _buffers.AsReadOnly();
    public IReadOnlyList<StorageZone> Storages => _storages.AsReadOnly();
    public IReadOnlyList<Ramp> Ramps => _ramps.AsReadOnly();

    public IReadOnlyList<ProductId> ProductIds => _productIds.AsReadOnly();
    public IReadOnlyList<PalletId> PalletIds => _palletIds.AsReadOnly();
    public IReadOnlyList<DeliveryInId> IncomeDeliveryIds => _deliveryInIds.AsReadOnly();
    public IReadOnlyList<DeliveryOutId> OutcomeDeliveryIds => _deliveryOutIds.AsReadOnly();

    public AdressId Location { get; }
    public string Name { get; } = null!;

    private Warehouse(WarehouseId id, string name, AdressId location)
        : base(id) => (Location, Name) = (location, name);

    public static Warehouse Create(int id, string name, AdressId location) =>
        new(WarehouseId.Create(id), name, location);
}
