using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.Infrastructure.Services;

public class CustomerServiceAsync : ICustomerServiceAsync
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IUserAddressRepository _userAddressRepository;
    private readonly IMapper _mapper;

    public CustomerServiceAsync(ICustomerRepository customerRepository, IAddressRepository addressRepository,
        IUserAddressRepository userAddressRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _addressRepository = addressRepository;
        _userAddressRepository = userAddressRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerAddressResponseModel>> GetCustomerAddressByUserIdAsync(int userId)
    {
        var customer = await _customerRepository.GetCustomerByUserId(userId).ToListAsync();
        return _mapper.Map<IEnumerable<CustomerAddressResponseModel>>(customer);
    }

    public async Task<UserAddressResponseModel> SaveCustomerAddressAsync(
        CustomerAddressRequestModel customerAddressRequestModel)
    {
        var customerAddress =  _mapper.Map<Address>(customerAddressRequestModel);
        var addressId = (await  _addressRepository.InsertAsync(customerAddress)).Id;
        var userAddress = new UserAddress()
        {
            AddressId = addressId,
            CustomerId = customerAddressRequestModel.CustomerId,
            IsDefaultAddress = customerAddressRequestModel.IsDefaultAddress
        };

        return _mapper.Map<UserAddressResponseModel>(await _userAddressRepository.InsertAsync(userAddress));
    }
}