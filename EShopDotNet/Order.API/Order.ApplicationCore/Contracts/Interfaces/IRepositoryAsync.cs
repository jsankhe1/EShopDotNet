namespace Order.ApplicationCore.Contracts.Interfaces;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll(); // ✅ Now Sync
    Task<T?> GetByIdAsync(int id); // ✅ Async for single record
    Task<T> InsertAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<int> DeleteByIdAsync(int id);
}