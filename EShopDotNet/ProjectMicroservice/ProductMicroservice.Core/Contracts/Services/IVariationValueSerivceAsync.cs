using ProductMicroservice.Core.Models.RequestModels;
using ProductMicroservice.Core.Models.ResponseModel;

namespace ProductMicroservice.Core.Contracts.Services;

public interface IVariationValueSerivceAsync
{
    Task<IEnumerable<VariationValueResponseModel>> GetAllAsync();
    Task<int> InsertAsync(VariationValueRequestModel entity);
}