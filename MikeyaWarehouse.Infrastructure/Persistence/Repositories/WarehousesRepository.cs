using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.WarehouseAggregate;

namespace MikeyaWarehouse.Infrastructure.Persistence.Repositories;

public class WarehousesRepository : GenericRepository<Warehouse>,
    IWarehousesRepository
{
    private readonly IDbContextFactory<MikeyaWarehouseDbContext> _dbContextFactory;

    public WarehousesRepository(IDbContextFactory<MikeyaWarehouseDbContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }

}
