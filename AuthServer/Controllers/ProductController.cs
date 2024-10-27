using AuthServer.Core.DTO_s;
using AuthServer.Core.GenericServices;
using AuthServer.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IServiceGeneric<Product, ProductDto> _service;

        public ProductController(IServiceGeneric<Product, ProductDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return ActionResultInstance(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductDto productDto)
        {
            return ActionResultInstance(await _service.AddAsync(productDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, ProductDto productDto)
        {
            return ActionResultInstance(await _service.Update(productDto, id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return ActionResultInstance(await _service.Remove(id));
        }


    }
}
