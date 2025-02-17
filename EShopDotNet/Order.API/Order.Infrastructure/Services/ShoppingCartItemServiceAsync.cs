using Order.ApplicationCore.Contracts.Services;

namespace Order.Infrastructure.Services;

public class ShoppingCartItemServiceAsync : IShoppingCartItemServiceAsync
{
    public Task<int> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}