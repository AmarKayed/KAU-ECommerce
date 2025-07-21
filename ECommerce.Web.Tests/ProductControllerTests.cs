using ECommerce.DAL.Interfaces;
using ECommerce.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ECommerce.Web.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            var controller = new ProductController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Default view
        }
    }
}
