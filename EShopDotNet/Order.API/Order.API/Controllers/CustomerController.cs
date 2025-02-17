using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Models.RequestModels;

namespace Order.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync _customerServiceAsync;

        public CustomerController(ICustomerServiceAsync customerServiceAsync)
        {
            _customerServiceAsync = customerServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerAddressByUserId(int userId)
        {
            var response = await _customerServiceAsync.GetCustomerAddressByUserIdAsync(userId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomerAddress(CustomerAddressRequestModel customerAddressRequestModel)
        {
            var reponse = await _customerServiceAsync.SaveCustomerAddressAsync(customerAddressRequestModel);
            return Ok(reponse);
        }
        
        
    }
}
