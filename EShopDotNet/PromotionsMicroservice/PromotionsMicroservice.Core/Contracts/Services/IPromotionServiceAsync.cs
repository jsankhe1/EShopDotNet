using PromotionsMicroservice.Core.Models.RequestModels;
using PromotionsMicroservice.Core.Models.ResponseModels;

namespace PromotionsMicroservice.Core.Contracts.Services;

public interface IPromotionServiceAsync
{
    Task<IEnumerable<PromotionResponseModel>> GetAllAsync();
    Task<PromotionResponseModel> GetByIdAsync(int id);
    Task<int> InsertAsync(PromotionRequestModel promotionRequestModel);
    Task<int> UpdateAsync(PromotionRequestModel promotionRequestModel);
    Task<int> DeleteAsync(int id);
    Task<IEnumerable<PromotionResponseModel>> GetPromotionByProductNameAsync(string productName);
    Task<IEnumerable<PromotionResponseModel>> GetActivePromotionsAsync();
    
}