using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Contracts.DTO;
using MikeyaWarehouse.Domain.ContractorsAggregate;

namespace MikeyaWarehouse.Infrastructure.Persistence.Repositories;

public class ContractorsRepository : GenericRepository<Contractor>,
    IContractorsRepository
    
{
    private readonly IDbContextFactory<MikeyaWarehouseDbContext> _dbContextFactory;

    public ContractorsRepository(IDbContextFactory<MikeyaWarehouseDbContext> dbContextFactory) 
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<ShipmentModel>> GetShipmentsWithContractorsAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .SelectMany(c => c.Shipments
                .Select(s => new ShipmentModel(s)))
            .ToListAsync();
    }
}
