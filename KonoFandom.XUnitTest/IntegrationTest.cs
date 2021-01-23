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
    public class IntegrationTest : IClassFixture<CustomWebApplicationFactory<TestStartup>>
    {
        private readonly WebApplicationFactory<TestStartup> _factory;

        public IntegrationTest(CustomWebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("Home/Privacy")]
        [InlineData("/Characters")]
        [InlineData("/Characters/Details/1")]
        [InlineData("/Cards")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
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

        [Fact]
        public async void Details_CharacterController_ReturnsViewWithViewModel()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CharactersController(context);

            var expected = new CharacterDetails();

            var character = new Character
            {
                Name = "Test",
                CharacterVoice = "Test",
                Biography = "Test",
                IconImagePath = "Test",
                CharacterImagePath = "Test"
            };

            var characters = new List<Character>()
            {
                new Character()
                {
                    Name = "Test",
                    CharacterVoice = "Test",
                    Biography = "Test",
                    IconImagePath = "Test",
                    CharacterImagePath = "Test"
                },
                new Character()
                {
                    Name = "Test2",
                    CharacterVoice = "Test2",
                    Biography = "Test2",
                    IconImagePath = "Test2",
                    CharacterImagePath = "Test2"
                }
            };

            expected.Character = character;
            expected.Characters = characters;
            const int id = 1;

            // Act
            var result = await controller.Details(id) as ViewResult;
            var model = result.Model as CharacterDetails;

            // Assert
            Assert.IsType<CharacterDetails>(model);
            Assert.NotNull(result);

        }
    }
}
