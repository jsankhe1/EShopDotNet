using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Core.Contracts.Services;
using ProductMicroservice.Core.Entities;
using ProductMicroservice.Core.Models.RequestModels;
using ProductMicroservice.Core.Models.ResponseModel;

namespace ProductMicroservice.Infrastructure.Services;

public class CategoryServiceAsync : ICategorySerivceAsync
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepositoryAsync _categoryRepositoryAsync;

    public CategoryServiceAsync(IMapper mapper, ICategoryRepositoryAsync categoryRepositoryAsync)
    {
        _mapper = mapper;
        _categoryRepositoryAsync = categoryRepositoryAsync;
    }
    public async Task<IEnumerable<ProductCategoryResponseModel>> GetCategoryByParentCategoryId(int parentCategoryId)
    {
        var categoiesByparent = await _categoryRepositoryAsync.GetAll()
            .AsNoTracking()
            .Where(c => c.ParentCategory.ParentCategoryId == parentCategoryId).ToListAsync();
        return _mapper.Map<IEnumerable<ProductCategoryResponseModel>>(categoiesByparent);
    }

    public async Task<IEnumerable<ProductCategoryResponseModel>> GetAllAsync()
    {
        var categories = await _categoryRepositoryAsync.GetAll().ToListAsync();
        return _mapper.Map<IEnumerable<ProductCategoryResponseModel>>(categories);
    }

    public async Task<ProductCategoryResponseModel?> GetByIdAsync(int id)
    {
        var modelOut = await _categoryRepositoryAsync.GetByIdAsync(id);
        return _mapper.Map<ProductCategoryResponseModel>(modelOut);
    }

    public async Task<int> InsertAsync(ProductCategoryRequestModel entity)
    {
        var categoryIn = _mapper.Map<ProductCategory>(entity);
        return await _categoryRepositoryAsync.InsertAsync(categoryIn);
    }

    public async Task<int> UpdateAsync(ProductCategoryRequestModel entity)
    {
        var categoryIn = _mapper.Map<ProductCategory>(entity);
        return await _categoryRepositoryAsync.UpdateAsync(categoryIn);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _categoryRepositoryAsync.DeleteByIdAsync(id);
    }
}