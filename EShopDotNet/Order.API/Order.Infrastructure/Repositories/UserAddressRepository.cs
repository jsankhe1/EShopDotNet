using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;



public class UserAddressRepository : BaseRepository<UserAddress>, IUserAddressRepository
{
    private readonly OrderDbContext _orderDbContext;

    public UserAddressRepository(OrderDbContext orderDbContext) : base(orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }
}