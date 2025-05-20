using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.ContractorsAggregate.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;
using MikeyaWarehouse.Domain.ShipmentAggregate.Enumerations;
using MikeyaWarehouse.Domain.ShipmentAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.ShipmentAggregate;

public sealed class Shipment : AggregateRoot<ShipmentId>
{
    private readonly List<PalletId> _pallets = [];

    public IReadOnlyList<PalletId> Pallets => _pallets.AsReadOnly();
    
    public ContractorId ContractorId { get; }
    public ShipmentType Type { get; }
    public ShipmentStatus Status { get; }
    public DateTime Requested { get; }
    public DateTime? Accomplished { get; }

    private Shipment(
        ShipmentId id,
        ContractorId contractorId,
        ShipmentType type,
        ShipmentStatus status,
        DateTime requested,
        DateTime? accomplished = null)
        : base(id)
    {
        ContractorId = contractorId;
        Type = type;
        Status = status;
        Requested = requested;
        Accomplished = accomplished;
    }

    public static Shipment Create(
        ContractorId contracor, 
        ShipmentType type, 
        ShipmentStatus status, 
        DateTime req, 
        DateTime? end)
    {
        return new(ShipmentId.CreateNew(), 
            contracor, type, status, req, end);
    }

}
