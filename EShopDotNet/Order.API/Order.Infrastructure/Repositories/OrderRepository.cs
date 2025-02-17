using Order.ApplicationCore.Contracts.Interfaces;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<ApplicationCore.Entities.Order>, IOrderRepository
{
    private readonly OrderDbContext _orderDbContext;

    public OrderRepository(OrderDbContext orderDbContext) : base(orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }



}