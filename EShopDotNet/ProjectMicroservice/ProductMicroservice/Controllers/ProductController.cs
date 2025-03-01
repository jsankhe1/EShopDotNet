using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Core.Contracts.Services;
using ProductMicroservice.Core.Models.RequestModels;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductSerivceAsync _productSerivceAsync;

        public ProductController(IProductSerivceAsync productSerivceAsync)
        {
            _productSerivceAsync = productSerivceAsync;
        }
        


        [HttpGet]
        public async Task<IActionResult> GetListProducts(int pageId = 1, int pageSize = 10, int? categoryId = null)
        {

            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await _productSerivceAsync.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductRequestModel productRequestModel)
        {
            var response = await _productSerivceAsync.InsertAsync(productRequestModel);
            if (response == 1)
            {
                return Ok("Saved");
            }
            else
            {
                return BadRequest("Error");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductRequestModel productRequestModel)
        {
            var response = await _productSerivceAsync.UpdateAsync(productRequestModel);
            if (response == 1)
            {
                return Ok("Saved");
            }
            else
            {
                return BadRequest("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByCategoryId(int categoryId)
        {
            var response = await _productSerivceAsync.GetProductByCategoryId(categoryId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var response = await _productSerivceAsync.GetProductByProductName(name);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productSerivceAsync.DeleteAsync(id);
            return Ok(result);
        }
    }
}
