using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.PalletAggregate.Enumerations;

public sealed class PalletType(int id, string name, string? description = null)
    : Enumeration(id, name, description)
{
    public static readonly PalletType FIN  = new(1, nameof(FIN), "1000x1200/(100)");
    public static readonly PalletType EURO = new(2, nameof(EURO), "800x1200/(100)");
    public static readonly PalletType EURO_STANDARD = new(3, nameof(EURO_STANDARD), "800x1200/(145)");
    
}
