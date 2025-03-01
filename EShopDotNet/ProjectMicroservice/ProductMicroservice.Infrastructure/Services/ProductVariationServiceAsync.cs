using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Core.Contracts.Services;
using ProductMicroservice.Core.Entities;
using ProductMicroservice.Core.Models.RequestModels;
using ProductMicroservice.Core.Models.ResponseModel;

namespace ProductMicroservice.Infrastructure.Services;

public class ProductVariationServiceAsync : IProductVariationSerivceAsync
{
    private readonly IMapper _mapper;
    private readonly IProductVariationRepositoryAsync _productVariationRepositoryAsync;

    public ProductVariationServiceAsync(IMapper mapper, IProductVariationRepositoryAsync productVariationRepositoryAsync)
    {
        _mapper = mapper;
        _productVariationRepositoryAsync = productVariationRepositoryAsync;
    }
    public async Task<IEnumerable<ProductVariationValueResponseModel>> GetAllAsync()
    {
        var productVariations = await _productVariationRepositoryAsync.GetAll().ToListAsync();
        return _mapper.Map<IEnumerable<ProductVariationValueResponseModel>>(productVariations);
    }

    public async Task<int> InsertAsync(ProductVariationValueRequestModel entity)
    {
        var modelIn = _mapper.Map<ProductVariationValues>(entity);
        return await _productVariationRepositoryAsync.InsertAsync(modelIn);
        
    }

    public Task<ProductVariationValueResponseModel> GetById()
    {
        throw new NotImplementedException();
    }

    public async Task<ProductVariationValueResponseModel> GetById(int id)
    {
        var modelOut = await _productVariationRepositoryAsync.GetByIdAsync(id);
        return _mapper.Map<ProductVariationValueResponseModel>(modelOut);
    }
}