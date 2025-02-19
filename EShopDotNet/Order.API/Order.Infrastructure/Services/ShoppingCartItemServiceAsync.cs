using AutoMapper;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Contracts.Services;

namespace Order.Infrastructure.Services;

public class ShoppingCartItemServiceAsync : IShoppingCartItemServiceAsync
{
    private readonly IMapper _mapper;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public ShoppingCartItemServiceAsync(IMapper mapper,IShoppingCartItemRepository shoppingCartItemRepository)
    {
        _mapper = mapper;
        _shoppingCartItemRepository = shoppingCartItemRepository;
    }
    public async Task<int> DeleteByIdAsync(int id)
    {
        return await _shoppingCartItemRepository.DeleteByIdAsync(id);
    }
}