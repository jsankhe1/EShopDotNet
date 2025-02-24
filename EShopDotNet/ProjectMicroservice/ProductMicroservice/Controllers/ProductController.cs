using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Core.Contracts.Services;

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
        public Task<IActionResult> GetListProducts()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<IActionResult> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> SaveProduct()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public Task<IActionResult> Update()
        {
            throw new NotImplementedException();
            
        }
        
        [HttpPut]
        public Task<IActionResult> InActive()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public Task<IActionResult> GetProductByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet]
        public Task<IActionResult> GetProductByName(string producyNsmr)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public Task<IActionResult> DeleteProduct()
        {
            throw new NotImplementedException();
        }
    }
}
