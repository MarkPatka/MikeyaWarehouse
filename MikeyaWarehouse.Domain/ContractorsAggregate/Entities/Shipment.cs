using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.ContractorsAggregate.Enumerations;
using MikeyaWarehouse.Domain.ContractorsAggregate.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.ContractorsAggregate.Entities;

public sealed class Shipment : Entity<ShipmentId>
{
    private readonly List<PalletId> _pallets = [];
    public IReadOnlyList<PalletId> PalletIds => _pallets.AsReadOnly();
    
    public ShipmentType Type { get; }
    public ShipmentStatus Status { get; }
    public DateTime Requested { get; }
    public DateTime? Accomplished { get; }

    private Shipment()
    {
        
    }

    private Shipment(
        ShipmentId id,
        ShipmentType type,
        ShipmentStatus status,
        DateTime requested,
        DateTime? accomplished = null)
        : base(id)
    {
        Type = type;
        Status = status;
        Requested = requested;
        Accomplished = accomplished;
    }

    public static Shipment Create(
        ShipmentType type, 
        ShipmentStatus status, 
        DateTime req, 
        DateTime? end)
    {
        return new(ShipmentId.CreateNew(), type, status, req, end);
    }

}
