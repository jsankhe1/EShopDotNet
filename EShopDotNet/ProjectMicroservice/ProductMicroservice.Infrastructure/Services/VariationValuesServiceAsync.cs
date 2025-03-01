using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Core.Contracts.Services;
using ProductMicroservice.Core.Entities;
using ProductMicroservice.Core.Models.RequestModels;
using ProductMicroservice.Core.Models.ResponseModel;

namespace ProductMicroservice.Infrastructure.Services;

public class VariationValuesServiceAsync : IVariationValueSerivceAsync
{
    private readonly IMapper _mapper;
    private readonly IVariationValueRepositoryAsync _variationValueRepositoryAsync;

    public VariationValuesServiceAsync(IMapper mapper, IVariationValueRepositoryAsync variationValueRepositoryAsync)
    {
        _mapper = mapper;
        _variationValueRepositoryAsync = variationValueRepositoryAsync;
    }
    public async Task<IEnumerable<VariationValueResponseModel>> GetAllAsync()
    {
        var variationValues = await _variationValueRepositoryAsync.GetAll().ToListAsync();
        return _mapper.Map<IEnumerable<VariationValueResponseModel>>(variationValues);
    }

    public async Task<int> InsertAsync(VariationValueRequestModel entity)
    {
        var modelIn = _mapper.Map<VariationValue>(entity);
        return await _variationValueRepositoryAsync.InsertAsync(modelIn);
    }
}