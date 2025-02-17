namespace Order.ApplicationCore.Contracts.Interfaces;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll(); // ✅ Now Sync
    Task<T?> GetByIdAsync(int id); // ✅ Async for single record
    Task<int> InsertAsync(T entity);
    Task<int> DeleteByIdAsync(int id);
    Task<int> UpdateAsync(T entity);
}