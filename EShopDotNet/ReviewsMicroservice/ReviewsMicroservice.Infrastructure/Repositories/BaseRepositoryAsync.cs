using ReviewsMicroservice.Core.Contracts.Interfaces;

namespace ReviewsMicroservice.Infrastructure.Repositories;

public class BaseRepositoryAsync<T> : IRepository<T> where T:class
{
    public IQueryable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> InsertAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}