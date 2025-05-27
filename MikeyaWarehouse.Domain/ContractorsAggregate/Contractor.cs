using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.ContractorsAggregate.Entities;
using MikeyaWarehouse.Domain.ContractorsAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.ContractorsAggregate;

public sealed class Contractor : AggregateRoot<ContractorId>
{
    private readonly List<Shipment> _shipments = [];
    public IReadOnlyList<Shipment> Shipments => _shipments.AsReadOnly();

    public string Name { get; } = null!;
    public ContractorAdress Adress { get; }


#pragma warning disable CS8618
    private Contractor() { }
#pragma warning restore CS8618


    private Contractor(ContractorId id, string name, ContractorAdress adress)
        : base(id)
    {
        Name = name;
        Adress = adress;
    }

    public static Contractor Create(int id, string name, ContractorAdress adress) =>
        new(ContractorId.Create(id), name, adress);
}
