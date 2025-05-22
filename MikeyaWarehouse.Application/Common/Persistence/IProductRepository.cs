using MikeyaWarehouse.Domain.ProductAggregate;
using MikeyaWarehouse.Domain.WarehouseAggregate;

namespace MikeyaWarehouse.Application.Common.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
}
