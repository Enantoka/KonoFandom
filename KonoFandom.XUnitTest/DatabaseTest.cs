using KonoFandom.Data;
using KonoFandom.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KonoFandom.XUnitTest
{
    public class DatabaseTest : FactoryFixture
    {
        private KonoFandomContext context;
        public DatabaseTest(CustomWebApplicationFactory<TestStartup> factory) : base(factory)
        {
            var service = _factory.Services;
            context = service.GetRequiredService<KonoFandomContext>();
        }

        [Fact]
        public void Index_Characters_ReturnsListOfCharacters()
        {
            // Arrange

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

            // Act
            var count = context.Character.Count();

            // Assert
            Assert.Equal(EXPECTED_COUNT, count);
            context.Database.RollbackTransaction();
        }
    }
}
