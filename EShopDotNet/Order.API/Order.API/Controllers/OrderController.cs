using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Models.RequestModels;
using Order.ApplicationCore.Models.ResponseModels;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
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
            IEnumerable<OrderResponseModel> orders = await _orderServiceAsync.GetAllAsync();
            return Ok(orders);
        }

        // POST: api/Order/New
        [HttpPost("New")]
        public async Task<IActionResult> SaveOrder([FromBody] OrderRequestModel order)
        {
            if (order == null)
                return BadRequest();

            int newOrderId = await _orderServiceAsync.InsertAsync(order);
            // Returning the new resource identifier, adjust if you add a GetById endpoint
            return CreatedAtAction(nameof(GetOrderById), new { id = newOrderId }, order);
        }

        // GET: api/Order/ByCustomer/5
        [HttpGet("ByCustomer/{customerId:int}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int customerId)
        {
            IEnumerable<OrderResponseModel> orders = await _orderServiceAsync.GetOrderByCustomerId(customerId);
            return Ok(orders);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            int result = await _orderServiceAsync.DeleteByIdAsync(id);
            if (result > 0)
                return NoContent();

            return NotFound();
        }

        // PUT: api/Order/Update
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderRequestModel order)
        {
            if (order == null)
                return BadRequest();

            int result = await _orderServiceAsync.UpdateAsync(order);
            if (result > 0)
                return NoContent();

            return NotFound();
        }

        // Optional: GET: api/Order/5 for CreatedAtAction above
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            OrderResponseModel order = await _orderServiceAsync.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}