using Lab7.Models;

namespace Lab7.Client.Services;

public interface IDataService<T> where T : ModelBase
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(Guid id, T entity);
    Task<bool> DeleteAsync(Guid id);
}
