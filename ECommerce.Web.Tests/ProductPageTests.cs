using Microsoft.Playwright;

namespace ECommerce.Web.Tests
{
    public class ProductPageTests
    {
        [Fact]
        public async Task ProductIndexPage_DisplaysProducts()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();

            // Change the URL to match your local dev server
            await page.GotoAsync("http://localhost:5088/Product");

            // Assert that the page contains expected content
            var content = await page.ContentAsync();
            Assert.Contains("Products", content); // Adjust to match your page's heading

            // Optionally, check for product items
            var productElements = await page.QuerySelectorAllAsync(".product-item"); // Use your actual CSS selector
            Assert.NotEmpty(productElements);

            await browser.CloseAsync();
        }
    }
}
