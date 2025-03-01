using ProductMicroservice.Core.Models.RequestModels;
using ProductMicroservice.Core.Models.ResponseModel;

namespace ProductMicroservice.Core.Contracts.Services;

public interface IProductVariationSerivceAsync
{
    Task<IEnumerable<ProductVariationValueResponseModel>> GetAllAsync();
    Task<int> InsertAsync(ProductVariationValueRequestModel entity);

    Task<ProductVariationValueResponseModel> GetById(int id);
}