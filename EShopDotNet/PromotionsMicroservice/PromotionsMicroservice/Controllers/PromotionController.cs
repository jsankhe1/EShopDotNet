using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionsMicroservice.Core.Contracts.Services;
using PromotionsMicroservice.Core.Models.RequestModels;

namespace PromotionsMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionServiceAsync _promotionServiceAsync;
        private readonly IMapper _mapper;

        public PromotionController(IPromotionServiceAsync promotionServiceAsync, IMapper mapper)
        {
            _promotionServiceAsync = promotionServiceAsync;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPromotion()
        {
            var response = await _promotionServiceAsync.GetAllAsync();
            return Ok(response);
        }
            
        [HttpPost]
        public async Task<IActionResult> CreatePromotion(PromotionRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _promotionServiceAsync.InsertAsync(requestModel);
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState.ToString());
            }

        }
        
        [HttpPut]
        public async Task<IActionResult> UpdatePromotion(PromotionRequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _promotionServiceAsync.InsertAsync(requestModel);
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState.ToString());
            }

        }
        
        [HttpGet]
        public async Task<IActionResult> GetPromotionById(int id)
        {
            var response = await _promotionServiceAsync.GetByIdAsync(id);
            return Ok(response);

        }

        
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var response = await _promotionServiceAsync.DeleteAsync(id);
            return Ok(response);

        }
        
        [HttpGet]
        public async Task<IActionResult> GetPromotionByProductName(string productName)
        {
            var response = await _promotionServiceAsync.GetPromotionByProductNameAsync(productName);
            return Ok(response);

        }
        
        [HttpGet]
        public async Task<IActionResult> GetActivePromotions()
        {
            var response = await _promotionServiceAsync.GetActivePromotionsAsync();
            return Ok(response);

        }
        
    }
}
