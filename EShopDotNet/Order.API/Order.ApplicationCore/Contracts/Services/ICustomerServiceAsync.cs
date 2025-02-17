using Order.ApplicationCore.Entities;

namespace Order.ApplicationCore.Contracts.Services;

public interface ICustomerServiceAsync
{
    Task<Customer> GetCustomerAddressesByUserId(int userId);
}