using AutoMapper;
using ProductMicroservice.Core.Entities;
using ProductMicroservice.Core.Models.RequestModels;
using ProductMicroservice.Core.Models.ResponseModel;

namespace ProductMicroservice.Core.Helpers;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Product, ProductRequestModel>().ReverseMap();
        CreateMap<Product, ProductResponseModel>().ReverseMap();
        CreateMap<CategoryVariation, CategoryVariationRequestModel>().ReverseMap();
        CreateMap<CategoryVariation, CategoryVariationResponseModel>().ReverseMap();
        CreateMap<ProductCategory, ProductCategoryRequestModel>().ReverseMap();
        CreateMap<ProductCategory, ProductCategoryResponseModel>().ReverseMap();
        CreateMap<ProductVariationValues, ProductVariationValueRequestModel>().ReverseMap();
        CreateMap<ProductVariationValues, ProductVariationValueResponseModel>().ReverseMap();
        CreateMap<VariationValue, VariationValueRequestModel>().ReverseMap();
        CreateMap<VariationValue, VariationValueResponseModel>().ReverseMap();
    }
}