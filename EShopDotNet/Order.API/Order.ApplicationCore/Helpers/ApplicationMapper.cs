using AutoMapper;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.ApplicationCore.Helpers;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Entities.Order, OrderRequestModel>().ReverseMap();
        CreateMap<Entities.Order, OrderResponseModel>().ReverseMap();
        
    }
}