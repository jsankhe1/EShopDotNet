using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class OrderDetailRepository : BaseRepository<OrderDetails>, IOrderDetailRepository
{
    private readonly OrderDbContext _orderDbContext;

    public OrderDetailRepository(OrderDbContext orderDbContext) : base(orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public IQueryable<OrderDetails> GetOrderDetailsByOrderId(int orderId)
    {
        return _orderDbContext.OrderDetails
            .Include(od => od.Order)
            .Where(o => o.OrderId == orderId);
    }
}