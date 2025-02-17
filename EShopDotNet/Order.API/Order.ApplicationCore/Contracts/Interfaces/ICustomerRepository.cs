using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
   IQueryable<Customer> GetCustomerByUserId(int userId);

}