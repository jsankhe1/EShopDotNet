using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.Infrastructure.Services;

public class ShoppingCartServiceAsync : IShoppingCartServiceAsync
{
    private readonly IMapper _mapper;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public ShoppingCartServiceAsync(IMapper mapper, IShoppingCartRepository shoppingCartRepository)
    {
        _mapper = mapper;
        _shoppingCartRepository = shoppingCartRepository;
    }
    public async Task<IEnumerable<ShoppingCartResponseModel>> GetShoppingCartByCustomerIdAsync(int customerId)
    {
        var shoppingCarts = _mapper.Map<IEnumerable<ShoppingCartResponseModel>>
            (await _shoppingCartRepository.GetShoppingCartByCustomerId(customerId).ToListAsync());
        return shoppingCarts;
    }

    public async Task<ShoppingCartResponseModel> InsertOrUpdateAsync(ShoppingCartRequestModel shoppingCartRequestModel)
    {
        var shoppingCartIn = _mapper.Map<ShoppingCart>(shoppingCartRequestModel);
        var shoppingCartOut = _mapper.Map<ShoppingCartResponseModel>(await _shoppingCartRepository.InsertAsync(shoppingCartIn));
        return shoppingCartOut;

    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _shoppingCartRepository.DeleteByIdAsync(id);
    }
}