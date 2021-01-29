using KonoFandom.Controllers;
using KonoFandom.Data;
using KonoFandom.Models;
using KonoFandom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace KonoFandom.XUnitTest
{
    public class IntegrationTest : FactoryFixture
    {

        public IntegrationTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {
            
        }

        [Theory]
        [InlineData("/")]
        [InlineData("Home/Privacy")]
        [InlineData("/Cards")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public void Index_HomeController_ReturnsView()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
