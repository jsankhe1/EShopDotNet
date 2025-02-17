using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.Infrastructure.Services;

public class ShoppingCartServiceAsync : IShoppingCartServiceAsync
{
    public Task<IEnumerable<ShoppingCartResponseModel>> GetShoppingCartByCustomerIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<ShoppingCartResponseModel> InsertOrUpdateAsync(ShoppingCartRequestModel shoppingCartRequestModel)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}