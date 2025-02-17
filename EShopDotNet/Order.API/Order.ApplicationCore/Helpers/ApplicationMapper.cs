using AutoMapper;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.ApplicationCore.Helpers;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Address, CustomerAddressRequestModel>().ReverseMap();
        CreateMap<UserAddress, CustomerAddressRequestModel>().ReverseMap();
        CreateMap<Address, AddressResponseModel>().ReverseMap();
        CreateMap<UserAddress, UserAddressResponseModel>().ReverseMap();
        CreateMap<Customer, CustomerAddressResponseModel>().ReverseMap();

        CreateMap<OrderDetails, OrderDetailResponseModel>().ReverseMap();
        CreateMap<Entities.Order, OrderRequestModel>().ReverseMap();
        CreateMap<Entities.Order, OrderResponseModel>().ReverseMap();
            
        CreateMap<PaymentType, PaymentTypeResponseModel>().ReverseMap();
        CreateMap<PaymentMethod, PaymentResponseModel>().ReverseMap();

        CreateMap<ShoppingCartItem, ShoppingCartItemResponseModel>().ReverseMap();
        CreateMap<ShoppingCart, ShoppingCartRequestModel>().ReverseMap();
        CreateMap<ShoppingCart, ShoppingCartResponseModel>().ReverseMap();
        
    }
}