using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.ContractorsAggregate.Entities;

namespace MikeyaWarehouse.Infrastructure.Persistence.Repositories;

public class ShipmentRepository : GenericRepository<Shipment>,
    IShipmentRepository
{
    private readonly IDbContextFactory<MikeyaWarehouseDbContext> _dbContextFactory;

    public ShipmentRepository(IDbContextFactory<MikeyaWarehouseDbContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }


}
