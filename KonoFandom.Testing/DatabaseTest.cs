using KonoFandom.Data;
using KonoFandom.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KonoFandom.Testing
{
    public class DatabaseTest : FactoryFixture
    {
        public DatabaseTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {
        }

        [Fact]
        public void Index_Characters_ReturnsListOfCharacters()
        {
            // Arrange
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();

            // Act
            var list = context.Character.ToList();

            // Assert
            Assert.IsType<List<Character>>(list);
        }

        [Fact]
        public void Create_Characters_ReturnsCorrectCount()
        {
            // Arrange
            const int EXPECTED_COUNT = 20; // 19 from seeded data
            var service = _factory.Services;
            var context = service.GetRequiredService<KonoFandomContext>();

            // Act
            context.Database.BeginTransaction();
            context.Character.AddRange(
                new Character
                {
                    Name = "Test",
                    CharacterVoice = "Test",
                    Birthday = new DateTime(2020, 6, 7),
                    Biography = "Test",
                    IconImagePath = "Test",
                    CharacterImagePath = "Test"
                }
            );
            context.SaveChanges();

            var count = context.Character.Count();
            context.Database.RollbackTransaction();

            // Assert
            Assert.Equal(EXPECTED_COUNT, count);
        }
    }
}
