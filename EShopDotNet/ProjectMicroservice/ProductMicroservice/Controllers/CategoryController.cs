using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Core.Contracts.Services;

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
        public Task<IActionResult> SaveCategory()
        {
            throw new NotImplementedException();

            
        }

        
        [HttpGet]
        public Task<IActionResult> GetAllCategory()
        {
            throw new NotImplementedException();

            
            
        }
        
        [HttpGet]
        public Task<IActionResult> GetCategoryById(int id)
        {
            
            throw new NotImplementedException();

        }





        [HttpDelete]

        public Task<IActionResult> Delete()
        {
            throw new NotImplementedException();

        }
        
        [HttpGet]
        public Task<IActionResult> GetCategoryByParentCategoryId(int parentId)
        {
            
            throw new NotImplementedException();

        }
    }
}
