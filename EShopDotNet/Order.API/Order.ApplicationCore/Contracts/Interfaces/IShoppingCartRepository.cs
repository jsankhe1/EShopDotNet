using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Interfaces;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    IQueryable<ShoppingCart> GetShoppingCartByCustomerId(int customerId);
}