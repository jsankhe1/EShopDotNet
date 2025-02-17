using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
{
    private readonly OrderDbContext _orderDbContext;

    public ShoppingCartRepository(OrderDbContext orderDbContext) : base(orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public IQueryable<ShoppingCart> GetShoppingCartByCustomerId(int customerId)
    {
        return _orderDbContext.ShoppingCarts
            .Include(sc => sc.ShoppingCartItems)
            .Where(sc => sc.CustomerId == customerId);
    }
}