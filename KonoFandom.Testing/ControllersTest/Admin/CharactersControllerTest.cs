/*using KonoFandom.Areas.Admin.Controllers;
using KonoFandom.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace KonoFandom.Testing.ControllersTest.Admin
{
    public class CharactersControllerTest : FactoryFixture
    {
        public CharactersControllerTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task Index_Redirects_UnauthenticatedUser()
        {
            // Arrange
            var request = "/Admin/Characters";
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
        public void Controller_RequiresAuthorization_ForDecoratedAuthorizeAttributes()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CharactersController(context);

            // Act
            var type = controller.GetType();
            var attributes = type.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            var roles = type.GetCustomAttributesData()[1];

            //Assert
            Assert.True(attributes.Any());
            Assert.Contains("Admin", roles.ToString());
            Assert.Contains("Moderator", roles.ToString());
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
        public async Task Details_ReturnsACharacter_ForView()
        {
            // Arrange
            const int ID = 1;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CharactersController(context);

            // Act
            var result = await controller.Details(ID);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Models.Character>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CharactersController(context);
            controller.ModelState.AddModelError("NewCharacter", "Invalid data input");

            // Act
            var result = await controller.Create(null);

            // Assert
    Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
*/