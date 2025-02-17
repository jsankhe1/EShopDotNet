using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.Services;
using Order.ApplicationCore.Entities;
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


        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderServiceAsync.GetAllOrdersAsync();
            return Ok(orders);
        }


        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderRequestModel orderRequestModel)
        {
            var response = await _orderServiceAsync.InsertAsync(orderRequestModel);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> CheckOrderHistory(int customerId)
        {
            var orderHistory = await _orderServiceAsync.CheckOrderHistoryAsync(customerId);
            return Ok(orderHistory);
        }

        [HttpGet]
        public async Task<IActionResult> CheckOrderStatus(int orderId)
        {
            var orderStatus = await _orderServiceAsync.CheckOrderStatusAsync(orderId);
            return Ok(orderStatus);
        }

        [HttpPut]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var status = await _orderServiceAsync.CancelOrderAsync(orderId);
            if (!status.IsSuccess)
            {
                return NotFound(new
                {
                    message = status.ErrorMessage
                });
            }

            return Ok(status.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderRequestModel orderRequestModel)
        {

            var orderIn = await _orderServiceAsync.UpdateOrderAsync(orderRequestModel);
            return Ok(orderIn);

        }

        [HttpPost]
        public async Task<IActionResult> CompleteOrder(int orderId)
        {
            var status = await _orderServiceAsync.CompleteOrderAsync(orderId);
            if (!status.IsSuccess)
            {
                return NotFound(new
                {
                    message = status.ErrorMessage
                });
            }

            return Ok(status.Data);
        }

    }
}