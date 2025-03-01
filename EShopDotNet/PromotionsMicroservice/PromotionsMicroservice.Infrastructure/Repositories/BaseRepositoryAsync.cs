using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.Core.Contracts.Interfaces;
using PromotionsMicroservice.Infrastructure.Data;

namespace PromotionsMicroservice.Infrastructure.Repositories;

public class BaseRepositoryAsync<T> : IRepository<T> where T : class
{
    private readonly PromotionDbContext _promotionDbContext;


    public BaseRepositoryAsync(PromotionDbContext promotionDbContext)
    {
        _promotionDbContext = promotionDbContext;
    }
    public IQueryable<T> GetAll()
    {
       return _promotionDbContext.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _promotionDbContext.FindAsync<T>(id);
    }

    public async Task<int> InsertAsync(T entity)
    {
        await _promotionDbContext.Set<T>().AddAsync(entity);
        return await _promotionDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
         _promotionDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
         return await _promotionDbContext.SaveChangesAsync();

    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        { 
            _promotionDbContext.Set<T>().Remove(entity);
        }

        return await _promotionDbContext.SaveChangesAsync();
    }
}