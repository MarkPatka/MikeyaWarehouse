using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.Entities;
using MikeyaWarehouse.Domain.ContractorsAggregate.ValueObjects;
using MikeyaWarehouse.Domain.ShipmentAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.ContractorsAggregate;

public sealed class Contractor : AggregateRoot<ContractorId>
{
    private readonly List<ShipmentId> _shipmentIds = [];

    public IReadOnlyList<ShipmentId> ShipmentIds => _shipmentIds.AsReadOnly();
    public string Name { get; } = null!;
    public ContractorAdress Adress { get; }

    private Contractor(ContractorId id, string name, ContractorAdress adress)
        : base(id)
    {
        Name = name;
        Adress = adress;
    }

    public static Contractor Create(int id, string name, ContractorAdress adress) =>
        new(ContractorId.Create(id), name, adress);
}
