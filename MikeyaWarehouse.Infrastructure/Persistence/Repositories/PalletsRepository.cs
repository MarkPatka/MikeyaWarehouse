using Microsoft.EntityFrameworkCore;
using MikeyaWarehouse.Application.Common.Persistence;
using MikeyaWarehouse.Domain.PalletAggregate;

namespace MikeyaWarehouse.Infrastructure.Persistence.Repositories;

public class PalletsRepository : GenericRepository<Pallet>,
    IPalletsRepository
{
    private readonly IDbContextFactory<MikeyaWarehouseDbContext> _dbContextFactory;

    public PalletsRepository(IDbContextFactory<MikeyaWarehouseDbContext> dbContextFactory)
        : base(dbContextFactory.CreateDbContext())
    {
        _dbContextFactory = dbContextFactory;
    }


}
