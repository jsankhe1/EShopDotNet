using ReviewsMicroservice.ApplicationCore.Models;
using ReviewsMicroservice.Core.Models.RequestModel;

namespace ReviewsMicroservice.Core.Contracts.Services;

public interface ICustomerReviewServiceAsync
{
    Task<IEnumerable<ReviewResponseModel>> GetAllAsync();
    Task<int> InsertAsync(CustomerReviewRequestModel review);
    Task<int> UpdateAsync(CustomerReviewRequestModel review);
    Task<int> DeleteAsync(int id);
    Task<ReviewResponseModel?> GetByIdAsync(int id);
    Task<IEnumerable<ReviewResponseModel>> GetByUserIdAsync(string userId);
    Task<IEnumerable<ReviewResponseModel>> GetByProductIdAsync(string productId);
    Task<IEnumerable<ReviewResponseModel>> GetByYearAsync(int year);
    Task<int> ApproveReviewAsync(int id);
    Task<int> RejectReviewAsync(int id);
}