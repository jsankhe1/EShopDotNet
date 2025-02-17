using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync _orderServiceAsync;

        public OrderController(IOrderServiceAsync orderServiceAsync)
        {
            _orderServiceAsync = orderServiceAsync;
        }

        // GET: api/Order/All
        [HttpGet("All")]
        public async Task<IActionResult> GetAllOrders()
        {
            IEnumerable<OrderResponseModel> orders = await _orderServiceAsync.GetAllOrdersAsync();
            return Ok(orders);
        }

        // POST: api/Order/New
        [HttpPost("New")]
        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderRequestModel orderRequestModel)
        {
            var response = await _orderServiceAsync.InsertAsync(orderRequestModel);
            return Ok(response);
        }
        
    }
}