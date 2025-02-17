using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T:class
{
    private readonly OrderDbContext _orderDbContext;

    public BaseRepository(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public IQueryable<T> GetAll()
    {
        return _orderDbContext.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _orderDbContext.FindAsync<T>(id);
    }

    public async Task<T> InsertAsync(T entity)
    {
        await _orderDbContext.Set<T>().AddAsync(entity);
         await _orderDbContext.SaveChangesAsync();
         return entity;
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _orderDbContext.Set<T>().Remove(entity);
        }

        return await _orderDbContext.SaveChangesAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _orderDbContext.Set<T>().Entry(entity).State = EntityState.Modified; 
        await _orderDbContext.SaveChangesAsync();
        return entity;
    }
}