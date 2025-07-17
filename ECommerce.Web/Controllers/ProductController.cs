using ECommerce.DAL.Interfaces;
using ECommerce.DAL.Models;
using ECommerce.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepository.GetAllProductsAsync();
            return View(products);
        }
    }
}
