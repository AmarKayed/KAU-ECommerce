using ECommerce.DAL.Interfaces;
using ECommerce.DAL.Models;
using ECommerceAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ECommerceAPI.Tests.Controllers
{
    public class ProductControllerTests
    {
        [Fact]
        public async Task GetProductsByName_ReturnsOkResult_WithProducts()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetProductsByNameAsync("Test"))
                    .ReturnsAsync(new List<Product> { new Product { Name = "Test" } });

            var controller = new ProductController(mockRepo.Object);

            // Act
            var result = await controller.GetProductsByName("Test");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var products = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Single(products);
            Assert.Contains(products, p => p.Name == "Test");
        }
    }
}
