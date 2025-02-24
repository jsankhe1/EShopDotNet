using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Core.Contracts.Services;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariationValue : ControllerBase
    {
        private readonly IVariationValueSerivceAsync _variationValueSerivceAsync;

        public VariationValue(IVariationValueSerivceAsync variationValueSerivceAsync)
        {
            _variationValueSerivceAsync = variationValueSerivceAsync;
        }
        [HttpPost]
        public Task<IActionResult> Save()
        {
            throw new NotImplementedException();
        }
    
        [HttpGet]
        public Task<IActionResult> GetProductVariationById(int id)
        {
            throw new NotImplementedException();
        }
    }
    
    



}
