using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Core.Contracts.Services;
using ProductMicroservice.Core.Models.RequestModels;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationSerivceAsync _productVariationSerivceAsync;

        public ProductVariationController(IProductVariationSerivceAsync productVariationSerivceAsync)
        {
            _productVariationSerivceAsync = productVariationSerivceAsync;
        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductVariationValueRequestModel productVariationValueRequestModel)
        {
            var response = await _productVariationSerivceAsync.InsertAsync(productVariationValueRequestModel);
            if (response == 1)
            {
                return Ok("Saved!");
            }
            else
            {
                return BadRequest("Error somewhere, not saved!");
            }
        }
    
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await _productVariationSerivceAsync.GetById(id);
            return Ok(response);
        }
    }
    
    



}
