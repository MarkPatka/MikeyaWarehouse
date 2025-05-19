using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Warehouse.Entities;
using MikeyaWarehouse.Domain.Warehouse.ValueObjects;

namespace MikeyaWarehouse.Domain.Warehouse;

public sealed class Warehouse : AggregateRoot<WarehouseId>
{
    private readonly List<BufferZone> _buffers = [];
    private readonly List<StorageZone> _storages = [];
    private readonly List<Ramp> _ramps = [];
    public string Name { get; } = null!;



}
