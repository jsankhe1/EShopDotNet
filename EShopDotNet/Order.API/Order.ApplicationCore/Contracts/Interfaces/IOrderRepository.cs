using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Interfaces;

public interface IOrderRepository : IRepository<Entities.Order>
{
    IQueryable<Entities.Order> GetOrdersByCustomerId(int customerId);
    IQueryable<PaymentMethod> GetPaymentByCustomerId(int customerId);
}