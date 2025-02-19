using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Interfaces;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartServiceAsync _shoppingCartServiceAsync;

        public ShoppingCartController(IShoppingCartServiceAsync shoppingCartServiceAsync)
        {
            _shoppingCartServiceAsync = shoppingCartServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingCartByCustomerId(int customerId)
        {
            var response = await _shoppingCartServiceAsync.GetShoppingCartByCustomerIdAsync(customerId);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> SaveShoppingCart(ShoppingCartRequestModel shoppingCartRequestModel)
        {
            var response = await _shoppingCartServiceAsync.InsertOrUpdateAsync(shoppingCartRequestModel);
            return Ok(response);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCart(int cartId)
        {
            var response = await _shoppingCartServiceAsync.DeleteAsync(cartId);
            return Ok(response);
        }
    }
}
