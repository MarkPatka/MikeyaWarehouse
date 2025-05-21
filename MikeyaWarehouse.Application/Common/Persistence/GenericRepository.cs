using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MikeyaWarehouse.Application.Common.Persistence;

public abstract class GenericRepository<TType>
    : IGenericRepository<TType> where TType : class
{
    protected readonly DbContext _dbContext;
    protected readonly DbSet<TType> _dbSet;

    protected GenericRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TType>();
    }

    public Task<TType> CreateAsync(TType entity)
    {
        throw new NotImplementedException();
    }

    public Task<TType> DeleteAsync(TType entity)
    {
        throw new NotImplementedException();
    }

    public Task<TType> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TType> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TType>> GetFilteredAsync(
        Expression<Func<TType, bool>> func, bool tracked = false)
    {
        throw new NotImplementedException();
    }

    public Task<TType> UpdateAsync(TType entity)
    {
        throw new NotImplementedException();
    }
}
