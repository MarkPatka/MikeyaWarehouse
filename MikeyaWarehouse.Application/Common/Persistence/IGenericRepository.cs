using System.Linq.Expressions;

namespace MikeyaWarehouse.Application.Common.Persistence;

public interface IGenericRepository<T> where T : class
{
    public Task<T?> GetAsync(int id);
    public Task<T?> GetAsync(Guid id);
    public Task CreateRangeAsync(IEnumerable<T> entities);
    public Task<IEnumerable<T>> GetFilteredAsync(
        Expression<Func<T, bool>> func, bool tracked = false);

    public IQueryable<T> GetAllAsQueryableAsNoTracking();

    public Task CreateAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
}
