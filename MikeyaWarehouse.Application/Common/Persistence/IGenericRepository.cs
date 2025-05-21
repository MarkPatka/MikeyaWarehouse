using System.Linq.Expressions;

namespace MikeyaWarehouse.Application.Common.Persistence;

public interface IGenericRepository<T> where T : class
{
    public Task<T> GetAsync(int id);
    public Task<T> GetAsync(Guid id);
    public Task<IEnumerable<T>> GetFilteredAsync(
        Expression<Func<T, bool>> func, bool tracked = false);

    public Task<T> CreateAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task<T> DeleteAsync(T entity);
}
