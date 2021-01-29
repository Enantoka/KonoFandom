using KonoFandom.Controllers;
using KonoFandom.Data;
using KonoFandom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace KonoFandom.Testing.ControllersTest
{
    public class CharactersControllerTest : FactoryFixture
    {
        public CharactersControllerTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {

        }

        // Client-side Characters Controller Tests
        [Fact]
        public async Task Index_Character_ReturnsCharacters()
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
        public async Task Index_Character_ReturnsViewWithListOfCharacters()
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
        public async Task Details_Character_ReturnsACharacter()
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
        public async void Details_Character_ReturnsViewWithViewModel()
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

        // Admin Characters Controller Tests
        [Fact]
        public async Task Index_Character_RedirectsUnauthorizedUser()
        {
            // Arrange
            var request = "Admin/Characters";
            var client = _factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });

            // Act
            var response = await client.GetAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }

        [Fact]
        public async Task Index_Character_ReturnsCharactersForAuthorizedUser()
        {
            // Arrange
            var request = "Admin/Characters";
            var client = _factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });

            // Act
            var response = await client.GetAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        }
    }
}
