using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Models.RequestModels;

namespace Order.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServiceAsync _paymentServiceAsync;

        public PaymentController(IPaymentServiceAsync paymentServiceAsync)
        {
            _paymentServiceAsync = paymentServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentByCustomerId(int customerId)
        {
            var response = await _paymentServiceAsync.GetPaymentByCustomerIdAsync(customerId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SavePayement(PaymentRequestModel paymentRequestModel)
        {
            var response = await _paymentServiceAsync.InsertAsync(paymentRequestModel);
            return Ok(response);

        }

        [HttpDelete]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var response = await _paymentServiceAsync.DeleteAsync(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePayment(PaymentRequestModel paymentRequestModel)
        {
            var response = await _paymentServiceAsync.UpdateAsync(paymentRequestModel);
            return Ok(response);
        }
    }
}
