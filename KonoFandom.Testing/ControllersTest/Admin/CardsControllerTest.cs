using KonoFandom.Areas.Admin.Controllers;
using KonoFandom.Data;
using KonoFandom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KonoFandom.Testing.ControllersTest.Admin
{
    public class CardsControllerTest : FactoryFixture
    {
        public CardsControllerTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {

        }

        [Theory]
        [InlineData("/Admin/Cards")]
        [InlineData("/Admin/Cards/Details/1")]
        [InlineData("/Admin/Cards/Create")]
        [InlineData("/Admin/Cards/Edit/1")]
        [InlineData("/Admin/Cards/Delete/1")]

        public async Task Pages_NotFound_UnauthenticatedGuest(string request) // Testing unauthenticated access of non-users of the application
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public void Controller_RequiresAuthorization_ForDecoratedAuthorizeAttributes()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

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
        public async Task Index_ReturnsListOfCards_ForView()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            // Act
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Card>>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task Details_ValidId_ReturnsCharacter()
        {
            // Arrange
            const int Id = 1;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CharactersController(context);

            // Act
            var result = await controller.Details(Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Character>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task Details_InvalidId_ReturnsPageNotFound()
        {
            // Arrange
            const int InvalidId = 999;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            // Act
            var result = await controller.Details(InvalidId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GET_Create_HasViewData()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            // Act
            var result = controller.Create();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<SelectList>(viewResult.ViewData["CharacterID"]);
            Assert.IsAssignableFrom<SelectList>(viewResult.ViewData["PassiveSkillID"]);
        }

        [Fact]
        public async Task POST_Create_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);
            controller.ModelState.AddModelError("NewCard", "Invalid data input");

            // Act
            var result = await controller.Create(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task POST_Create_RedirectToIndex_GivenValidModel()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            var card =
                new Card
                {
                    CharacterID = 1,
                    Name = "Test",
                    Rarity = 1,
                    RarityImagePath = "Test",
                    ImagePath = "Test"
                };

            // Act
            context.Database.BeginTransaction();
            var result = await controller.Create(card);
            context.Database.RollbackTransaction();

            // Assert
            var actionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", actionResult.ActionName);
        }

        [Fact]
        public void POST_Create_HasViewData()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            // Act
            var result = controller.Create();
            var viewResult = result as ViewResult;

            //Assert
            Assert.IsAssignableFrom<SelectList>(viewResult.ViewData["CharacterID"]);
            Assert.IsAssignableFrom<SelectList>(viewResult.ViewData["PassiveSkillID"]);
        }

        [Fact]
        public async Task GET_Edit_ValidId_ReturnsCard()
        {
            // Arrange
            const int Id = 1;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            // Act
            var result = await controller.Edit(Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Card>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task GET_Edit_InvalidId_ReturnsNotFound()
        {
            // Arrange
            const int InvalidId = 999;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            // Act
            var result = await controller.Edit(InvalidId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GET_Edit_HasViewData()
        {
            // Arrange
            const int Id = 1;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            // Act
            var result = await controller.Edit(Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<SelectList>(viewResult.ViewData["CharacterID"]);
            Assert.IsAssignableFrom<SelectList>(viewResult.ViewData["PassiveSkillID"]);
            Assert.IsAssignableFrom<List<AssignedElementData>>(viewResult.ViewData["Elements"]);
        }

        [Fact]
        public async Task POST_Edit_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange
            const int Id = 1;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);
            controller.ModelState.AddModelError("EditCard", "Invalid data input");

            var card =
                new Card
                {
                    CardID = 1,
                    Name = "Test",
                    Rarity = 1,
                    RarityImagePath = "Test",
                    ImagePath = "Test"
                };

            // Act
            var result = await controller.Edit(Id, null, card);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task POST_Edit_RedirectToIndex_GivenValidModel()
        {
            // Arrange
            const int Id = 1;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            var card =
                new Card
                {
                    CharacterID = 1,
                    CardID = 1,
                    Name = "Test",
                    Rarity = 1,
                    RarityImagePath = "Test",
                    ImagePath = "Test"
                };

            // Act
            context.Database.BeginTransaction();
            var result = await controller.Edit(Id, null, card);
            context.Database.RollbackTransaction();

            // Assert
            var actionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", actionResult.ActionName);
        }

        [Fact]
        public async Task GET_Delete_ValidId_ReturnsCard()
        {
            // Arrange
            const int Id = 1;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            // Act
            var result = await controller.Delete(Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Card>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task GET_Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange
            const int InvalidId = 999;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            // Act
            var result = await controller.Delete(InvalidId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task POST_DeleteConfirmed_RedirectToIndex_GivenId()
        {
            // Arrange
            const int Id = 2;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new CardsController(context);

            // Act
            context.Database.BeginTransaction();
            var result = await controller.DeleteConfirmed(Id);
            context.Database.RollbackTransaction();

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", viewResult.ActionName);
        }
    }
}
