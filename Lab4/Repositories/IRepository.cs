using Lab4.Models;
using System.Threading.Tasks;
using System;

namespace Lab4.Repositories;

public interface IRepository<T> where T : ModelBase
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(Guid id, T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
