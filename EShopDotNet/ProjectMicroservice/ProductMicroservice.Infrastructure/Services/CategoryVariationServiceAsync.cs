using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Core.Contracts.Services;
using ProductMicroservice.Core.Entities;
using ProductMicroservice.Core.Models.RequestModels;
using ProductMicroservice.Core.Models.ResponseModel;

namespace ProductMicroservice.Infrastructure.Services;

public class CategoryVariationServiceAsync : ICategoryVariationSerivceAsync
{
    private readonly IMapper _mapper;
    private readonly ICategoryVariationRepository _categoryVariationRepository;

    public CategoryVariationServiceAsync(IMapper mapper, ICategoryVariationRepository categoryVariationRepository)
    {
        _mapper = mapper;
        _categoryVariationRepository = categoryVariationRepository;
    }
    public async Task<IEnumerable<CategoryVariationResponseModel>> GetCategoryVariationByCategoryId(int categoryId)
    {
        var categoryVariatiosnByCategoryId = await _categoryVariationRepository
            .GetAll()
            .Where(c => c.CategoryId == categoryId)
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<CategoryVariationResponseModel>>(categoryVariatiosnByCategoryId);
    }

    public async Task<IEnumerable<CategoryVariationResponseModel>> GetAllAsync()
    {
        var categoryVariatiosnOut = await _categoryVariationRepository
            .GetAll()
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<CategoryVariationResponseModel>>(categoryVariatiosnOut);
    }

    public async Task<CategoryVariationResponseModel?> GetByIdAsync(int id)
    {
        var categoryVariationOut = await _categoryVariationRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryVariationResponseModel>(categoryVariationOut);
    }

    public async Task<int> InsertAsync(CategoryVariationRequestModel entity)
    {
        var modelIn = _mapper.Map<CategoryVariation>(entity);
        return await _categoryVariationRepository.UpdateAsync(modelIn);
    }

    public async Task<int> UpdateAsync(CategoryVariationRequestModel entity)
    {
        var modelIn = _mapper.Map<CategoryVariation>(entity);
        return await _categoryVariationRepository.UpdateAsync(modelIn);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _categoryVariationRepository.DeleteByIdAsync(id);
    }
}