using AutoMapper;
using ReviewsMicroservice.Core.Entities;
using ReviewsMicroservice.Core.Models.RequestModel;

namespace ReviewsMicroservice.Core.Helpers;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<CustomerReview, CustomerReviewRequestModel>().ReverseMap();
    }
}