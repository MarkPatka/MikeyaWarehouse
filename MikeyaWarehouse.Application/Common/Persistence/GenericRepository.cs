using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;
using System.Transactions;

namespace MikeyaWarehouse.Application.Common.Persistence;

/// <summary>
/// Aggregates general repository methods (common for all repositories) 
/// <br />and typed I...Repository In turn have a scecific for the type methods
/// </summary>
/// <typeparam name="TType"></typeparam>
public abstract class GenericRepository<TType>
    : IGenericRepository<TType> where TType : class
{
    protected readonly DbContext _dbContext;
    protected readonly DbSet<TType> _dbSet;

    protected IDbContextTransaction? Transaction { get; set; }
    
    protected GenericRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TType>();
    }

    public async Task CreateAsync(TType entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAsync();
    }

    public async Task CreateRangeAsync(IEnumerable<TType> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await SaveAsync();
    }

    public async Task DeleteAsync(TType entity)
    {
        _dbSet.Remove(entity);
        await SaveAsync();
    }
    
    public async Task<IEnumerable<TType>> GetFilteredAsync(
        Expression<Func<TType, bool>> filter, bool tracked = false)
    {
        if (!tracked)
        {
            IQueryable<TType> set = _dbSet
                .AsNoTracking()
                .Where(filter);

            var result = await set.ToListAsync();
            return result;
        }
        else
        {
            IQueryable<TType> set = _dbSet.Where(filter);
            
            var result = await set.ToListAsync();
            return result;
        }
    }

    public async Task UpdateAsync(TType entity)
    {
        _dbSet.Update(entity);
        await SaveAsync();
    }

    public async Task<TType?> GetAsync(int id) =>
        await _dbSet.FindAsync(id);
    public async Task<TType?> GetAsync(Guid id) =>
        await _dbSet.FindAsync(id);
    private async Task SaveAsync() =>
        await _dbContext.SaveChangesAsync();

    protected async Task ExecuteInASharedTransactionAsync(Func<Task> asyncAction)
    {
        var strategy = _dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            using var transaction = new CommittableTransaction(
                new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted });

            _dbContext.Database.EnlistTransaction(transaction);
            await asyncAction();
            transaction.Commit();
        });
    }
}
