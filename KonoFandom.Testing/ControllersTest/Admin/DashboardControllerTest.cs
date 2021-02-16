using KonoFandom.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KonoFandom.Testing.ControllersTest.Admin
{
    public class DashboardControllerTest : FactoryFixture
    {
        public DashboardControllerTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task Pages_NotFound_UnauthenticatedGuest() // Testing unauthenticated access of non-users of the application
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = "/Admin/Dashboard";

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
            var controller = new DashboardController();

            // Act
            var type = controller.GetType();
            var attributes = type.GetCustomAttributes(typeof(AuthorizeAttribute), true);
            var roles = type.GetCustomAttributesData()[1];

            //Assert
            Assert.True(attributes.Any());
            Assert.Contains("Admin", roles.ToString());
            Assert.Contains("Moderator", roles.ToString());
        }
    }
}
