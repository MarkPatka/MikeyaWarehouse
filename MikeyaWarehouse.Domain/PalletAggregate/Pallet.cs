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
    
    public DateOnly Expires { get; }
    public Dimensions Dimensions { get; } = null!;
    public PalletType Type { get; } = PalletType.EURO_STANDARD;
    
    private Pallet(PalletId id, PalletType type)
        : base(id) => Type = type;

    public static Pallet Create(PalletType type) =>
        new(PalletId.Create(Guid.NewGuid()), type);
}
