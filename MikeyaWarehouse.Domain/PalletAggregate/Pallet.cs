using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.Entities;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate.Entities;
using MikeyaWarehouse.Domain.PalletAggregate.Enumerations;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;

namespace MikeyaWarehouse.Domain.PalletAggregate;

public class Pallet : AggregateRoot<PalletId>
{
    private readonly List<ProductBox> _boxes = [];
    public IReadOnlyList<ProductBox> ProductBoxes => _boxes.AsReadOnly();
    
    public DateOnly Expires => _boxes.Min(x => x.Expire); // { get; }
    public Dimensions Dimensions { get; } = null!;
    public PalletType Type { get; } = PalletType.EURO_STANDARD;


    private Pallet()
    {
        
    }

    private Pallet(PalletId id, PalletType type)
        : base(id)
    {
        Type = type;

        var (length, width, height, weight) = type.Id switch
        {
            1 => (
                GlobalConstants.FIN_PALLET_LENGTH,
                GlobalConstants.FIN_PALLET_WIDTH,
                GlobalConstants.FIN_PALLET_HEIGHT,
                GlobalConstants.FIN_PALLET_WEIGHT),
            2 => (
                GlobalConstants.EURO_PALLET_LENGTH,
                GlobalConstants.EURO_PALLET_WIDTH,
                GlobalConstants.EURO_PALLET_HEIGHT,
                GlobalConstants.EURO_PALLET_WEIGHT),
            3 => (
                GlobalConstants.EURO_STANDARD_PALLET_LENGTH,
                GlobalConstants.EURO_STANDARD_PALLET_WIDTH,
                GlobalConstants.EURO_STANDARD_PALLET_HEIGHT,
                GlobalConstants.EURO_STANDARD_PALLET_WEIGHT),
            _ => (0d, 0d, 0d, 0d)
        };

        Dimensions = new Dimensions()
        {
            Length = length,
            Width  = width,
            Height = height,
            Weight = weight
        };
    }
    public void AddBox(ProductBox box)
    {
        ArgumentNullException.ThrowIfNull(box);
        ArgumentNullException.ThrowIfNull(box.Dimensions);
        _boxes.Add(box);
    }

    public static Pallet Create(PalletType type) =>
        new(PalletId.Create(Guid.NewGuid()), type);
}
