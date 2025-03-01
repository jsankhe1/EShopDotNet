using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Core.Contracts.Services;
using ProductMicroservice.Core.Models.RequestModels;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategorySerivceAsync _categorySerivceAsync;

        public CategoryController(ICategorySerivceAsync categorySerivceAsync)
        {
            _categorySerivceAsync = categorySerivceAsync;
        }


        [HttpPost]
        public async Task<IActionResult> SaveCategory(ProductCategoryRequestModel productCategoryRequestModel)
        {
            var response = await _categorySerivceAsync.InsertAsync(productCategoryRequestModel);
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
        public async Task<IActionResult> GetAllCategory()
        {
            var response = await (_categorySerivceAsync.GetAllAsync());
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await (_categorySerivceAsync.GetByIdAsync(id));
            return Ok(response);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categorySerivceAsync.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryByParentCategoryId(int parentId)
        {
            var response = await _categorySerivceAsync.GetCategoryByParentCategoryId(parentId);
            return Ok(response);

        }
    }
}