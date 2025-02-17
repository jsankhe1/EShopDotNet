using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.ApplicationCore.Contracts.Services;

public interface IShoppingCartServiceAsync
{
    
    
    Task<IEnumerable<ShoppingCartResponseModel>> GetShoppingCartByCustomerIdAsync(int customerId);
    Task<ShoppingCartResponseModel> InsertOrUpdateAsync(ShoppingCartRequestModel shoppingCartRequestModel);
    Task<int> DeleteAsync(int id);
}