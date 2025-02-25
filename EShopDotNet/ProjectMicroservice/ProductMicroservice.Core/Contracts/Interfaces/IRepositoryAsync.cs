namespace ProductMicroservice.Core.Contracts.Interfaces;

public interface IRepository<T> where T : class{
    IQueryable<T> GetAll(); // 
    Task<T?> GetByIdAsync(int id); 
    Task<T> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteByIdAsync(int id);
}