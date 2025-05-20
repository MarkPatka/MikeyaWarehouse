using MikeyaWarehouse.Domain.Common.Abstract;

namespace MikeyaWarehouse.Domain.WarehouseAggregate.Enumerations;

public sealed class StorageBinStatus(int id, string name, string? description = null)
    : Enumeration(id, name, description)
{
    public static readonly StorageBinStatus AVAILABLE = new(1, nameof(AVAILABLE), "Доступна");
    public static readonly StorageBinStatus OCCUPIED  = new(2, nameof(OCCUPIED), "Заполнена");
    public static readonly StorageBinStatus RESERVED  = new(3, nameof(RESERVED), "Резерв");

}
