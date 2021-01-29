using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KonoFandom.XUnitTest.ControllersTest
{
    public class HomeControllerTest : FactoryFixture
    {
        public HomeControllerTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {

        }

        [Theory]
        [InlineData("/")]
        [InlineData("Home/Privacy")]
        public async Task Get_HomeEndpoints_ReturnSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
