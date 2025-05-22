using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.ContractorsAggregate;

namespace MikeyaWarehouse.Infrastructure.Persistence.Repositories;

public class ContractorRepository : GenericRepository<Contractor>,
    IContractorsRepository
    
{
    private readonly IDbContextFactory<MikeyaWarehouseDbContext> _dbContextFactory;

    public ContractorRepository(IDbContextFactory<MikeyaWarehouseDbContext> dbContextFactory) 
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }



}
