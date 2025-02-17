using System.Collections;
using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<ApplicationCore.Entities.Order>, IOrderRepository
{
    private readonly OrderDbContext _orderDbContext;

    public OrderRepository(OrderDbContext orderDbContext) : base(orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }


    public IQueryable<ApplicationCore.Entities.Order> GetOrdersByCustomerId(int customerId)
    {
        return _orderDbContext.Orders
            .Include(o => o.OrderDetails)
            .Where(o => o.CustomerId == customerId);
    }

    public IQueryable<PaymentMethod> GetPaymentByCustomerId(int customerId)
    {
        return _orderDbContext
            .Orders
            .Where(o => customerId == o.CustomerId)
            .SelectMany(o => o.PaymentMethods);
    }
}