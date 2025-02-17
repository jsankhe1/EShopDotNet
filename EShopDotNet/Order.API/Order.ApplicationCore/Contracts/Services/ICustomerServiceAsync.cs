using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.ApplicationCore.Contracts.Services;

public interface ICustomerServiceAsync
{
    Task<IEnumerable<CustomerAddressResponseModel>> GetCustomerAddressByUserIdAsync(int userId);
    Task<UserAddressResponseModel> SaveCustomerAddressAsync(CustomerAddressRequestModel customerAddressRequestModel);
}