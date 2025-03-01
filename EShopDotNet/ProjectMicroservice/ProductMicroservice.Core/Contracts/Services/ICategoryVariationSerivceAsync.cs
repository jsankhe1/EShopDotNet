using ProductMicroservice.Core.Models.RequestModels;
using ProductMicroservice.Core.Models.ResponseModel;

namespace ProductMicroservice.Core.Contracts.Services;

public interface ICategoryVariationSerivceAsync
{
    Task<IEnumerable<CategoryVariationResponseModel>> GetCategoryVariationByCategoryId(int categoryId);
    Task<IEnumerable<CategoryVariationResponseModel>> GetAllAsync();
    Task<CategoryVariationResponseModel?> GetByIdAsync(int id);
    Task<int> InsertAsync(CategoryVariationRequestModel entity);
    Task<int> UpdateAsync(CategoryVariationRequestModel entity);
    Task<int> DeleteAsync(int id);
}