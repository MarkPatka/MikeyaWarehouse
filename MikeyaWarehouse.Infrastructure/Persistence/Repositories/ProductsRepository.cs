using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.PalletAggregate.Entities;

namespace MikeyaWarehouse.Infrastructure.Persistence.Repositories;

public class ProductsRepository : GenericRepository<Product>,
    IProductsRepository
{
    private readonly IDbContextFactory<MikeyaWarehouseDbContext> _dbContextFactory;

    public ProductsRepository(IDbContextFactory<MikeyaWarehouseDbContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }



}
