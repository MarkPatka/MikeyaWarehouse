using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.ContractorsAggregate.Entities;

namespace MikeyaWarehouse.Infrastructure.Persistence.Repositories;

public class ShipmentsRepository : GenericRepository<Shipment>,
    IShipmentsRepository
{
    private readonly IDbContextFactory<MikeyaWarehouseDbContext> _dbContextFactory;

    public ShipmentsRepository(IDbContextFactory<MikeyaWarehouseDbContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }


}
