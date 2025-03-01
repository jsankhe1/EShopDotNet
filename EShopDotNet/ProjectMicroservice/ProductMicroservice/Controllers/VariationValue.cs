using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Core.Contracts.Services;
using ProductMicroservice.Core.Models.RequestModels;

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
        public async Task<IActionResult> Save(VariationValueRequestModel variationValueRequestModel)
        {
            var response = await _variationValueSerivceAsync.InsertAsync(variationValueRequestModel);
            if (response == 1)
            {
                return Ok("Saved!");
            }

            else
            {
                return BadRequest("Not Saved, Error!");
            }
        }
    
        [HttpGet]
        public async Task<IActionResult> GetVariationId()
        {
            var response = await _variationValueSerivceAsync.GetAllAsync();
            return Ok(response);
        }
    }
    
    



}
