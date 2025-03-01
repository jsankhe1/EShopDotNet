using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Core.Contracts.Interfaces;
using ProductMicroservice.Core.Contracts.Services;
using ProductMicroservice.Core.Entities;
using ProductMicroservice.Core.Models.RequestModels;
using ProductMicroservice.Core.Models.ResponseModel;

namespace ProductMicroservice.Infrastructure.Services;

public class ProductServiceAsync : IProductSerivceAsync
{
    private readonly IMapper _mapper;
    private readonly IProductRepositoryAsync _productRepositoryAsync;

    public ProductServiceAsync(IMapper mapper, IProductRepositoryAsync productRepositoryAsync)
    {
        _mapper = mapper;
        _productRepositoryAsync = productRepositoryAsync;
    }
    public Task<IEnumerable<ProductResponseModel>> GetListProducts(int pageId, int pageSize, int? categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductResponseModel>> GetProductByCategoryId(int categoryId)
    {
        var productsByCategory = await _productRepositoryAsync.GetAll()
            .AsNoTracking()
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ProductResponseModel>>(productsByCategory);
    }

    public async Task<IEnumerable<ProductResponseModel>> GetProductByProductName(string productName)
    {
        var productsByName = await _productRepositoryAsync.GetAll()
            .AsNoTracking()
            .Where(p => p.Name == productName)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ProductResponseModel>>(productsByName);
    }

    public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
    {
        var products = await _productRepositoryAsync.GetAll()
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<ProductResponseModel>>(products);

    }

    public async Task<ProductResponseModel?> GetByIdAsync(int id)
    {
        var product = await _productRepositoryAsync.GetByIdAsync(id);
        return _mapper.Map<ProductResponseModel>(product);
    }

    public async Task<int> InsertAsync(ProductRequestModel entity)
    {
       var productIn =  _mapper.Map<Product>(entity);
       return await _productRepositoryAsync.InsertAsync(productIn);
    }

    public async Task<int> UpdateAsync(ProductRequestModel entity)
    {
        var productIn =  _mapper.Map<Product>(entity);
        return await _productRepositoryAsync.UpdateAsync(productIn);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _productRepositoryAsync.DeleteByIdAsync(id);
    }
}