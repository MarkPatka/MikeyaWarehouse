using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.Warehouse.Enumerations;

public sealed class RampStatus(int id, string name, string? description = null)
    : Enumeration(id, name, description)
{
    public static readonly RampStatus OPEN = new(1, nameof(OPEN), "Открыта для погрузки/разгрузки.");
    public static readonly RampStatus CLOSED = new(2, nameof(CLOSED), "Закрыта.");
    public static readonly RampStatus LOADING = new(3, nameof(LOADING), "Идет погрузка.");
    public static readonly RampStatus UNLOADING = new(4, nameof(UNLOADING), "Идет разгрузка.");
    public static readonly RampStatus MAINTENANCE = new(5, nameof(MAINTENANCE), "Технические работы. Рампа недоступна.");
}
