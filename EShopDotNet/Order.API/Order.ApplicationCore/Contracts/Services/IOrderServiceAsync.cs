using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.ApplicationCore.Contracts.Services;

public interface IOrderServiceAsync
{
    Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync();
    
    Task<OrderResponseModel> InsertAsync(OrderRequestModel reqModel);
    
    // Returns orders for a specific customer (Order History)
    Task<IEnumerable<OrderDetailResponseModel>> CheckOrderHistoryAsync(int customerId);
    
    // Returns a specific order (e.g., to check order status)
    Task<string> CheckOrderStatusAsync(int orderId);
    Task<(bool IsSuccess, OrderResponseModel? Data, string? ErrorMessage)> CompleteOrderAsync(int orderId);
    Task<(bool IsSuccess, OrderResponseModel? Data, string? ErrorMessage)> CancelOrderAsync(int orderId);

    Task<bool> UpdateOrderStatusAsync(int id, string status);

}