using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.PalletAggregate.Entities;

namespace MikeyaWarehouse.Infrastructure.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>,
    IProductRepository
{
    private readonly IDbContextFactory<MikeyaWarehouseDbContext> _dbContextFactory;

    public ProductRepository(IDbContextFactory<MikeyaWarehouseDbContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }



}
