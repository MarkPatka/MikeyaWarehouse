using MikeyaWarehouse.Domain.Common.Abstract;
using MikeyaWarehouse.Domain.WarehouseAggregate.Enumerations;

namespace MikeyaWarehouse.Domain.ProductAggregate.Enumerations;

public sealed class ProductStatus(int id, string name, string? description = null)
    : Enumeration(id, name, description)
{
    public static readonly ProductStatus IN_STOCK   = new(1, nameof(IN_STOCK), "В наличии");
    public static readonly ProductStatus IN_TRANSIT = new(2, nameof(IN_TRANSIT), "В пути");
    public static readonly ProductStatus RESERVED   = new(3, nameof(RESERVED), "Резерв");

}
