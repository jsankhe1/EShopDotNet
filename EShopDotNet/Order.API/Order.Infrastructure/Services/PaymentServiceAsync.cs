using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.Infrastructure.Services;

public class PaymentServiceAsync : IPaymentServiceAsync
{
    public Task<IEnumerable<PaymentResponseModel>> GetPaymentByCustomerIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentResponseModel> InsertAsync(PaymentRequestModel paymentRequestModel)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentResponseModel> UpdateAsync(PaymentRequestModel paymentRequestModel)
    {
        throw new NotImplementedException();
    }
}