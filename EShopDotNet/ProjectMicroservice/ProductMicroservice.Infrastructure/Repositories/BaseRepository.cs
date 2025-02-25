using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T:class
{
    private readonly ProductDbContext _productDbContext;


    public BaseRepository(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }
    public IQueryable<T> GetAll()
    {
        return _productDbContext.Set<T>().AsNoTracking();

    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _productDbContext.Set<T>().FindAsync(id);
    }

    public async Task<T> InsertAsync(T entity)
    {
        await _productDbContext.Set<T>().AddAsync(entity);
         await _productDbContext.SaveChangesAsync();
         return entity;
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _productDbContext.Entry(entity).State = EntityState.Modified;
        return await _productDbContext.SaveChangesAsync();
        
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _productDbContext.Remove(entity);
        }

        return await _productDbContext.SaveChangesAsync();
    }
}