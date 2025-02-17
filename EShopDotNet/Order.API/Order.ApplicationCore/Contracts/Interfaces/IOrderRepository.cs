namespace Order.ApplicationCore.Contracts.Interfaces;

public interface IOrderRepository : IRepository<Entities.Order>
{
    IQueryable<Entities.Order> GetOrdersByCustomerId(int customerId);
}