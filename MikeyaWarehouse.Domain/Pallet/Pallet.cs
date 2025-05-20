using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.Pallet.Entities;
using MikeyaWarehouse.Domain.Pallet.Enumerations;
using MikeyaWarehouse.Domain.Product.ValueObjects;

namespace MikeyaWarehouse.Domain.Pallet;

public sealed class Pallet : AggregateRoot<PalletId>
{
    private readonly List<ProductBox> _boxes = [];
    private readonly List<ProductId> _rowItemsIds = [];// to store the items without a box (like a large ones)
    
    public IReadOnlyList<ProductBox> ProductBoxes => _boxes.AsReadOnly();
    public IReadOnlyList<ProductId> ProductIds => _rowItemsIds.AsReadOnly();
    public PalletType Type { get; } = PalletType.EURO_STANDARD;
    public Dimensions Dimensions { get; }

    private Pallet(PalletId id, PalletType type, Dimensions dimensions)
        : base(id)
    {
        Type = type;
        Dimensions = dimensions;
    }

    public static Pallet Create(
        int id,  PalletType type, Dimensions dimensions)
    {
        return new(PalletId.Create(id), type, dimensions);
    }
}
