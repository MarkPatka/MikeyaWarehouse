using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate.Entities;
using MikeyaWarehouse.Domain.PalletAggregate.Enumerations;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.PalletAggregate;

public sealed class Pallet : AggregateRoot<PalletId>
{
    private readonly List<ProductBox> _boxes = [];
    
    public IReadOnlyList<ProductBox> ProductBoxes => _boxes.AsReadOnly();
    public PalletType Type { get; } = PalletType.EURO_STANDARD;
    public Dimensions Dimensions { get; }

    private Pallet(PalletId id, PalletType type, Dimensions dimensions)
        : base(id)
    {
        Type = type;
        Dimensions = dimensions;
    }

    public static Pallet Create(
        PalletType type, Dimensions dimensions)
    {
        return new(PalletId.Create(Guid.NewGuid()), type, dimensions);
    }
}
