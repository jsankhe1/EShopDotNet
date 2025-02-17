using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;
using Order.Infrastructure.Repositories;

namespace Order.Infrastructure.Services;

public class OrderServiceAsync : IOrderServiceAsync
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMemoryCache _memoryCache;
    private readonly IMapper _mapper;

    public OrderServiceAsync(IOrderRepository orderRepository, IMemoryCache memoryCache, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _memoryCache = memoryCache;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync()
    {
        var response = _memoryCache.Get<IEnumerable<OrderResponseModel>>("orders");
        if (response == null)
        {
            response = _mapper.Map<IEnumerable<OrderResponseModel>>
                (await _orderRepository.GetAll().ToListAsync());
            _memoryCache.Set("orders", response, TimeSpan.FromMinutes(1));
        }

        return response;
    }


    public async Task<OrderResponseModel> InsertAsync(OrderRequestModel reqModel)
    {
        var orderIn = _mapper.Map<ApplicationCore.Entities.Order>(reqModel);
        var orderOut = await _orderRepository.InsertAsync(orderIn);
        return _mapper.Map<OrderResponseModel>(orderOut);
    }


    public async Task<OrderResponseModel> UpdateAsync(OrderRequestModel reqModel)
    {
        var orderIn = _mapper.Map<ApplicationCore.Entities.Order>(reqModel);
        var orderOut = await _orderRepository.UpdateAsync(orderIn);
        return _mapper.Map<OrderResponseModel>(orderOut);
    }


    public async Task<IEnumerable<OrderDetailResponseModel>> CheckOrderHistoryAsync(int customerId)
    {

        var orders = await _orderRepository.GetOrdersByCustomerId(customerId).ToListAsync();
        return _mapper.Map<IEnumerable<OrderDetailResponseModel>>(orders);
    }

    public async Task<string> CheckOrderStatusAsync(int orderId)
    {
        var orderStatus = await _orderRepository.GetByIdAsync(orderId);
        return orderStatus?.OrderStatus.ToString() ?? "Not Found";
    }
    public async Task<(bool IsSuccess, OrderResponseModel? Data, string? ErrorMessage)> CompleteOrderAsync(int orderId)
    {
        var orderIn = await _orderRepository.GetByIdAsync(orderId);
        if (orderIn == null)
        {
            return (false, null, "Couldn't complete order, doesn't exist");
        }

        orderIn.OrderStatus = OrderStatus.Completed;
        var updatedOrder = await _orderRepository.UpdateAsync(orderIn);
        var orderOut = _mapper.Map<OrderResponseModel>(updatedOrder);
        return (true, orderOut, null);
    }


    public async Task<(bool IsSuccess, OrderResponseModel? Data, string? ErrorMessage)> CancelOrderAsync(int orderId)
    {
        var orderIn = await _orderRepository.GetByIdAsync(orderId);
        if (orderIn == null)
        {
            return (false, null, "Couldn't cancel order, since it doesn't exist");
        }

        orderIn.OrderStatus = OrderStatus.Cancelled;
        var updatedOrder = await _orderRepository.UpdateAsync(orderIn);
        var orderOut = _mapper.Map<OrderResponseModel>(updatedOrder);
        return (true, orderOut, null);
    }

    


    public async Task<bool> UpdateOrderStatusAsync(int id, string status)
    {
        if (!Enum.TryParse(status, true, out OrderStatus orderStatus))
        {
            return false;
        }

        var orderIn = await _orderRepository.GetByIdAsync(id);
        if (orderIn == null)
        {
            return false;
        }

        orderIn.OrderStatus = orderStatus;
        await _orderRepository.UpdateAsync(orderIn);
        return true;
    }
    
    // For Admins
    
    public async Task<int> DeleteByIdAsync(int id)
    {
        return await _orderRepository.DeleteByIdAsync(id);
    }
}