using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.ApplicationCore.Contracts.Services;

public interface IPaymentServiceAsync
{
    Task<IEnumerable<PaymentResponseModel>> GetPaymentByCustomerIdAsync(int customerId);
    Task<PaymentResponseModel> InsertAsync(PaymentRequestModel paymentRequestModel);
    Task<int> DeleteAsync(int id);
    Task<PaymentResponseModel> UpdateAsync(PaymentRequestModel paymentRequestModel);
}