using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Core.Contracts.Services;

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
        public Task<IActionResult> SaveProduct()
        {
            throw new NotImplementedException();
        }
    
        [HttpGet]
        public Task<IActionResult> GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
    
    



}
