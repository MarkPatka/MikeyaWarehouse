using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.Common.ValueObjects;
using MikeyaWarehouse.Domain.PalletAggregate.Entities;
using MikeyaWarehouse.Domain.PalletAggregate.Enumerations;
using MikeyaWarehouse.Domain.PalletAggregate.ValueObjects;
using MikeyaWarehouse.Domain.Common.Entities;

namespace MikeyaWarehouse.Domain.PalletAggregate;

public sealed class Pallet : AggregateRoot<PalletId>
{
    private readonly List<ProductBox> _boxes = [];
    
    public IReadOnlyList<ProductBox> ProductBoxes => _boxes.AsReadOnly();
    public DateOnly Expires => GetMinExpireDate();
    public PalletType Type { get; } = PalletType.EURO_STANDARD;
    public Dimensions Dimensions => GetPalletDimensions();

    
    private Pallet(PalletId id, PalletType type)
        : base(id)
    {
        Type = type;
    }

    public static Pallet Create(PalletType type)
    {
        return new(PalletId.Create(Guid.NewGuid()), type);
    }

    public DateOnly GetMaxExpireDate()
    {
        if (_boxes.Count == 0)
            return DateOnly.MinValue;

        DateOnly maxValue = _boxes[0].Expire;
        for (int i = 1; i < _boxes.Count; i++)
        {
            if (_boxes[i].Expire > maxValue)
            {
                maxValue = _boxes[i].Expire;
            }
        }
        return maxValue;
    }
    private DateOnly GetMinExpireDate()
    {
        if (_boxes.Count == 0)
            return DateOnly.MinValue;

        DateOnly minValue = _boxes[0].Expire;
        for (int i = 1; i < _boxes.Count; i++) 
        {
            if (_boxes[i].Expire < minValue)
            {
                minValue = _boxes[i].Expire;
            }
        }
        return minValue;
    }
    private Dimensions GetPalletDimensions()
    {
        var (length, width, height, weight) = Type.Id switch
        {
            1 => (
                GlobalConstants.FIN_LENGTH,
                GlobalConstants.FIN_WIDTH,
                GlobalConstants.FIN_HEIGHT,
                GlobalConstants.FIN_WEIGHT),
            2 => (
                GlobalConstants.EURO_LENGTH,
                GlobalConstants.EURO_WIDTH,
                GlobalConstants.EURO_HEIGHT,
                GlobalConstants.EURO_WEIGHT),
            3 => (
                GlobalConstants.EURO_STANDARD_LENGTH,
                GlobalConstants.EURO_STANDARD_WIDTH,
                GlobalConstants.EURO_STANDARD_HEIGHT,
                GlobalConstants.EURO_STANDARD_WEIGHT),
            _ => (0d, 0d, 0d, 0d)
        };

        if (_boxes.Count == 0)
            return new Dimensions
            {
                Length = length,
                Width  = width,
                Height = height,
                Weight = weight
            };

        var box = _boxes.First();
        var boxesInRow = (length * width) / (box.Dimensions.Length * box.Dimensions.Width);
        var rowsCount = _boxes.Count / boxesInRow;

        height += rowsCount == 0
            ? box.Dimensions.Height
            : box.Dimensions.Height * rowsCount;

        weight += _boxes.Count * box.Dimensions.Weight;

        return new Dimensions
        {
            Height = height,
            Width  = width,
            Weight = weight,
            Length = length
        };
    }
}
