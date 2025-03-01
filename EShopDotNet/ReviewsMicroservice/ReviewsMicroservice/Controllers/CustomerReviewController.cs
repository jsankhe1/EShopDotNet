using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewsMicroservice.Core.Contracts.Services;
using ReviewsMicroservice.Core.Models.RequestModel;

namespace ReviewsMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class CustomerReviewController : ControllerBase
    {
        private readonly ICustomerReviewServiceAsync _reviewServiceAsync;

        public CustomerReviewController(ICustomerReviewServiceAsync reviewServiceAsync)
        {
            _reviewServiceAsync = reviewServiceAsync;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetCustomerReviews()
        {
            var response = await _reviewServiceAsync.GetAllAsync();
            return Ok(response);
        }
            
        [HttpPost]
        public async Task<IActionResult> CreateReview(CustomerReviewRequestModel reviewRequestModel)
        {
            if (ModelState.IsValid)
            {
                
                var response = await _reviewServiceAsync.InsertAsync(reviewRequestModel);
                return Ok(response);
            }
            return BadRequest(ModelState.ToString());

        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateReview(CustomerReviewRequestModel reviewRequestModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _reviewServiceAsync.UpdateAsync(reviewRequestModel);
                return Ok(response);
            }
            return BadRequest(ModelState.ToString());

        }

        
        
        [HttpDelete]
        public async Task<IActionResult> DeleteShipperById(int id)
        {
            var response =await _reviewServiceAsync.DeleteAsync(id);
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerReviewById(int id)
        {
            var response =await _reviewServiceAsync.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerReviewByUserId(string userId)
        {
            var response =await _reviewServiceAsync.GetByUserIdAsync(userId);
            return Ok(response);

        }
        
        [HttpGet]
        public async Task<IActionResult> GetCustomerReviewByProductId(string productId)
        {
            var response = await _reviewServiceAsync.GetByProductIdAsync(productId);
            return Ok(response);

        }
        
        [HttpGet]
        public async Task<IActionResult> GetCustomerReviewsByYear(int year)
        {
            var response = await _reviewServiceAsync.GetByYearAsync(year);
            return Ok(response);

        }
        
        [HttpPut]
        public async Task<IActionResult> ApproveCustomerById(int id)
        {
            var response = await _reviewServiceAsync.ApproveReviewAsync(id);
            return Ok(response);

        }
        
        [HttpPut]
        public async Task<IActionResult> RejectCustomerReviewById(int id)
        {
            var response = await _reviewServiceAsync.RejectReviewAsync(id);
            return Ok(response);

        }
    }
}
