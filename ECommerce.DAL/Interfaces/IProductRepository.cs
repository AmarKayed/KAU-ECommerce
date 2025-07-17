using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.DAL.Models;

namespace ECommerce.DAL.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<Product> GetProductByIdAsync(Guid id);
        public Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(Guid categoryId);
        public Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
        public Task AddProductAsync(Product product);
        public Task UpdateProductAsync(Product product);
        public Task DeleteProductAsync(Guid id);

    }
}
