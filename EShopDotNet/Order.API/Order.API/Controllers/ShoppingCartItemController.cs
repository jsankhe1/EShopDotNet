using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.Infrastructure.Services;

namespace Order.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShoppingCartItemServiceAsync _shoppingCartItemServiceAsync;

        public ShoppingCartItemController(IShoppingCartItemServiceAsync shoppingCartItemServiceAsync)
        {
            _shoppingCartItemServiceAsync = shoppingCartItemServiceAsync;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCartItemById(int itemId)
        {
            var response = await _shoppingCartItemServiceAsync.DeleteByIdAsync(itemId);
            return Ok(response);

        }
    }
}
