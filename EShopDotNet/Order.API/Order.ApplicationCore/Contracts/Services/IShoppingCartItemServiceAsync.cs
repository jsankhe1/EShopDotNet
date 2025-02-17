namespace Order.ApplicationCore.Contracts.Services;

public interface IShoppingCartItemServiceAsync
{
    Task<int> DeleteByIdAsync(int id);

}