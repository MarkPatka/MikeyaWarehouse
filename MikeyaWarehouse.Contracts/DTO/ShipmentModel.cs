using MikeyaWarehouse.Domain.ContractorsAggregate.Entities;

namespace MikeyaWarehouse.Contracts.DTO;

public record ShipmentModel
{
    public Guid Id { get; set; }
    public int ContractorName { get; set; }
    public int PalletsCount { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public DateTime Requested { get; }
    public DateTime? Accomplished { get; }

    public ShipmentModel(Shipment shipment)
    {
        Id = shipment.Id.Value;
        PalletsCount = shipment.PalletIds.Count;
        Type = shipment.Type.Name;
        Status = shipment.Status.Name;
        Requested = shipment.Requested;
        Accomplished = shipment.Accomplished;
    }
}
