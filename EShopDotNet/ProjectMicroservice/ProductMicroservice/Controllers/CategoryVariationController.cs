using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Core.Contracts.Services;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryVariationController : ControllerBase
    {
        private readonly ICategoryVariationSerivceAsync _categoryVariationSerivceAsync;

        public CategoryVariationController(ICategoryVariationSerivceAsync categoryVariationSerivceAsync)
        {
            _categoryVariationSerivceAsync = categoryVariationSerivceAsync;
        }


        [HttpPost]
        public Task<IActionResult> SaveCategorVariation()
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<IActionResult> GetCategoryVariationById(int id)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public Task<IActionResult> GetCategoryVariationByCategoryId(int parentId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public Task<IActionResult> Delete()
        {
            throw new NotImplementedException();
        }
    }
}