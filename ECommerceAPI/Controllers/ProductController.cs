using ECommerce.DAL.Interfaces;
using ECommerce.DAL.Models;
using ECommerce.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<Product>> GetProductById([FromRoute] Guid Id)
        {
            return Ok(new Product());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByName([FromQuery] string name)
        {
            return Ok(await _productRepository.GetProductsByNameAsync(name));
        }

        // Notice that you can use IActionResult regardless of status code and data type that is being 
        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }
            await _productRepository.AddProductAsync(product);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }
            await _productRepository.UpdateProductAsync(product);
            return Ok();
        }
    }
}
