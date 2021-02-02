/*using KonoFandom.Controllers;
using KonoFandom.Data;
using KonoFandom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace KonoFandom.Testing.ControllersTest
{
    public class CardsControllerTest : FactoryFixture
    {

        public CardsControllerTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {
            
        }

        [Fact]
        public async Task Index_ReturnsCards_ForView()
        {
            // Arrange
            var request = "/Cards";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Index_ReturnsViewModel_ForView()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<CardIndex>(viewResult.ViewData.Model);
        }
    }
}
*/