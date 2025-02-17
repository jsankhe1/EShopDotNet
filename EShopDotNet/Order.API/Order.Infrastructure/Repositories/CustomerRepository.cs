using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Entities;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    private readonly OrderDbContext _orderDbContext;

    public CustomerRepository(OrderDbContext orderDbContext) : base(orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }


    public IQueryable<Customer> GetCustomerByUserId(int userId)
    {
        return _orderDbContext.Customers
            .Include(c => c.UserAddresses)
            .Where(c => c.UserId == userId);
    }
}