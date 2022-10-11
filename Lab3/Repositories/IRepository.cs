using Lab3.Models;
using MongoDB.Bson;

namespace Lab3.Repositories;

public interface IRepository<T> where T : ModelBase
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(ObjectId id);
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(ObjectId id, T entity);
    Task<bool> DeleteAsync(ObjectId id);
}
