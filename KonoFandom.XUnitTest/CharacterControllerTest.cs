using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KonoFandom.XUnitTest
{
    public class CharacterControllerTest : FactoryFixture
    {
        public CharacterControllerTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {

        }

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
        public async Task Index_Character_ReturnsACharacter()
        {
            // Arrange
            var request = "/Characters/Details/1";
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
