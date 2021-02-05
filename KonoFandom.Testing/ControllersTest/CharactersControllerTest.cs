using KonoFandom.Controllers;
using KonoFandom.Data;
using KonoFandom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace KonoFandom.Testing.ControllersTest
{
    public class CharactersControllerTest : FactoryFixture
    {
        public CharactersControllerTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task Index_ReturnsCharacters_ForGivenRequest()
        {
            // Arrange
            var request = "/Characters";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Index_ReturnsListOfCharacters_ForView()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CharactersController(context);

            // Act
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Models.Character>>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task Details_ReturnsCharacter_ForView()
        {
            // Arrange
            var request = "/Characters/Details/1";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Details_ValidId_ReturnsViewModel()
        {
            // Arrange
            const int ID = 1;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CharactersController(context);

            // Act
            var result = await controller.Details(ID);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<CharacterDetails>(viewResult.ViewData.Model);
        }
    }
}
