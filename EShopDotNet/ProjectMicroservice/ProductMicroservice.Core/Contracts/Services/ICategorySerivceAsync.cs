using ProductMicroservice.Core.Models.RequestModels;
using ProductMicroservice.Core.Models.ResponseModel;

namespace ProductMicroservice.Core.Contracts.Services;

public interface ICategorySerivceAsync
{
    Task<IEnumerable<ProductCategoryResponseModel>> GetCategoryByParentCategoryId(int parentCategoryId);
    Task<IEnumerable<ProductCategoryResponseModel>> GetAllAsync();
    Task<ProductCategoryResponseModel?> GetByIdAsync(int id);
    Task<int> InsertAsync(ProductCategoryRequestModel entity);
    Task<int> UpdateAsync(ProductCategoryRequestModel entity);
    Task<int> DeleteAsync(int id);
}