using MikeyaWarehouse.Domain.PalletAggregate;

namespace MikeyaWarehouse.Wpf.Models.Domain;

public record PalletModel
{
    public Guid Id           { get; }
    public string TypeName   { get; } = null!;
    public DateOnly Expires  { get; }
    public string Dimensions { get; } = null!;
    public double Volume     { get; }
    public double Weight     { get; }
    public int BoxesCount    { get; }

    public PalletModel(Pallet pallet)
    {
            Id = pallet.Id.Value;
            TypeName = pallet.Type.Name;
            Expires = pallet.Expires;
            Dimensions = $"{pallet.Dimensions.Length}" +
                         $"x{pallet.Dimensions.Width}" +
                         $"x{pallet.Dimensions.Height}";
            Volume = pallet.Dimensions.Volume;
            Weight = pallet.Dimensions.Weight;
            BoxesCount = pallet.ProductBoxes.Count;
        
    }
}
