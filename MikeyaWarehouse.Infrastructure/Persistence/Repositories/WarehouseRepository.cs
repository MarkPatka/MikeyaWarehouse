using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.WarehouseAggregate;

namespace MikeyaWarehouse.Infrastructure.Persistence.Repositories;

public class WarehouseRepository : GenericRepository<Warehouse>,
    IWarehouseRepository
{
    private readonly IDbContextFactory<MikeyaWarehouseDbContext> _dbContextFactory;

    public WarehouseRepository(IDbContextFactory<MikeyaWarehouseDbContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }

}
