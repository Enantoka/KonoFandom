using KonoFandom.Areas.Admin.Controllers;
using KonoFandom.Data;
using KonoFandom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class BasicSkillsControllerTest : FactoryFixture
    {
        public BasicSkillsControllerTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {

        }

        [Theory]
        [InlineData("/Admin/BasicSkills")]
        [InlineData("/Admin/BasicSkills/Details/1")]
        [InlineData("/Admin/BasicSkills/Create")]
        [InlineData("/Admin/BasicSkills/Edit/1")]
        [InlineData("/Admin/BasicSkills/Delete/1")]

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
            var controller = new BasicSkillsController(context);

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
        public async Task Index_ReturnsListOfBasicSkills_ForView()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);

            // Act
            var result = await controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<BasicSkill>>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task Details_ValidId_ReturnsBasicSkill()
        {
            // Arrange
            const int Id = 9;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);

            // Act
            var result = await controller.Details(Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<BasicSkill>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task Details_InvalidId_ReturnsPageNotFound()
        {
            // Arrange
            const int InvalidId = 999;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);

            // Act
            var result = await controller.Details(InvalidId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task POST_Create_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);
            controller.ModelState.AddModelError("NewBasicSkill", "Invalid data input");

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
            var controller = new BasicSkillsController(context);

            var basicSkill =
                new BasicSkill
                {
                    SkillID = 100,
                    Name = "Test",
                    Description = "Test",
                    ChargeTime = 0,
                    ImagePath = "Test"
                };

            // Act
            context.Database.BeginTransaction();
            var result = await controller.Create(basicSkill);
            context.Database.RollbackTransaction();

            // Assert
            var actionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", actionResult.ActionName);
        }

        [Fact]
        public async Task GET_Edit_ValidId_ReturnsBasicSkill()
        {
            // Arrange
            const int Id = 9;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);

            // Act
            var result = await controller.Edit(Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<BasicSkill>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task GET_Edit_InvalidId_ReturnsNotFound()
        {
            // Arrange
            const int InvalidId = 999;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);

            // Act
            var result = await controller.Edit(InvalidId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GET_Edit_HasViewData()
        {
            // Arrange
            const int Id = 9;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);

            // Act
            var result = await controller.Edit(Id);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task POST_Edit_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange
            const int Id = 9;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);
            controller.ModelState.AddModelError("EditBasicSkill", "Invalid data input");

            var basicSkill =
                new BasicSkill
                {
                    SkillID = 9,
                    Name = "Test",
                    Description = "Test",
                    ChargeTime = 0,
                    ImagePath = "Test"
                };

            // Act
            var result = await controller.Edit(Id, basicSkill);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task POST_Edit_RedirectToIndex_GivenValidModel()
        {
            // Arrange
            const int Id = 9;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);

            var basicSkill =
                new BasicSkill
                {
                    SkillID = 9,
                    Name = "Test",
                    Description = "Test",
                    ChargeTime = 0,
                    ImagePath = "Test"
                };

            // Act
            context.Database.BeginTransaction();
            var result = await controller.Edit(Id, basicSkill);
            context.Database.RollbackTransaction();

            // Assert
            var actionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", actionResult.ActionName);
        }

        [Fact]
        public async Task GET_Delete_ValidId_ReturnsBasicSkill()
        {
            // Arrange
            const int Id = 9;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);

            // Act
            var result = await controller.Delete(Id);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<BasicSkill>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task GET_Delete_InvalidId_ReturnsNotFound()
        {
            // Arrange
            const int InvalidId = 999;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);

            // Act
            var result = await controller.Delete(InvalidId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task POST_DeleteConfirmed_RedirectToIndex_GivenId()
        {
            // Arrange
            const int Id = 10;
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();
            var controller = new BasicSkillsController(context);

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
