using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Contracts.Services;
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

    public async Task<IEnumerable<OrderResponseModel>> GetAllAsync()
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

    public async Task<IEnumerable<OrderResponseModel>> GetOrderByCustomerId(int customerId)
    {
        var response = _mapper.Map<IEnumerable<OrderResponseModel>>
            (await _orderRepository.GetAll().Where(o => o.CustomerId == customerId).ToListAsync());

        return response;
    }

    public async Task<OrderResponseModel> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        return _mapper.Map<OrderResponseModel>(order);
    }

    public async Task<int> InsertAsync(OrderRequestModel reqModel)
    {
        var orderIn = _mapper.Map<ApplicationCore.Entities.Order>(reqModel);
        return await _orderRepository.InsertAsync(orderIn);
    }

    public async Task<int> UpdateAsync(OrderRequestModel reqModel)
    {
        var orderIn = _mapper.Map<ApplicationCore.Entities.Order>(reqModel);
        return await _orderRepository.UpdateAsync(orderIn);
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        return await _orderRepository.DeleteByIdAsync(id);
    }
}