using ProductMicroservice.Core.Models.RequestModels;
using ProductMicroservice.Core.Models.ResponseModel;

namespace ProductMicroservice.Core.Contracts.Services;

public interface IProductSerivceAsync
{
    Task<IEnumerable<ProductResponseModel>> GetListProducts(int pageId, int pageSize, int? categoryId);
    Task<IEnumerable<ProductResponseModel>> GetProductByCategoryId(int categoryId);
    Task<IEnumerable<ProductResponseModel>> GetProductByProductName(string productName);
    Task<IEnumerable<ProductResponseModel>> GetAllAsync();
    Task<ProductResponseModel?> GetByIdAsync(int id);
    Task<int> InsertAsync(ProductRequestModel entity);
    Task<int> UpdateAsync(ProductRequestModel entity);
    Task<int> DeleteAsync(int id);
}