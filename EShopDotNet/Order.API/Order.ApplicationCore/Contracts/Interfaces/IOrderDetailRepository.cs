using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Interfaces;

public interface IOrderDetailRepository
{
    IQueryable<OrderDetails> GetOrderDetailsByOrderId(int orderId);
}