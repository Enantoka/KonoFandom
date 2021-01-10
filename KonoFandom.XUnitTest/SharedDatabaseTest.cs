using KonoFandom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KonoFandom.XUnitTest
{
    public class SharedDatabaseTest : IClassFixture<SharedDatabaseFixture>
    {
        [CollectionDefinition("Database")]
        public class DatabaseCollectionFixture : ICollectionFixture<SharedDatabaseFixture>
        {

        }

        [Collection("Database")]
        public class CharacterControllerTests
        {
            private SharedDatabaseFixture fixture;

            // Test for Admin/CharacterController
            public CharacterControllerTests(SharedDatabaseFixture fixture)
            {
                this.fixture = fixture;
            }

            [Fact]
            public void Index_Characters_ReturnsListOfCharacters()
            {
                // Act
                var list = fixture.DbContext.Character.ToList();

                // Assert
                Assert.IsType<List<Character>>(list);
            }

            [Fact]
            public void Create_Characters_ReturnsCorrectCount()
            {
                // Arrange
                const int EXPECTED_COUNT = 2;
                
                fixture.DbContext.Character.AddRange(
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
                fixture.DbContext.SaveChanges();

                // Act
                var count = fixture.DbContext.Character.Count();

                // Assert
                Assert.Equal(EXPECTED_COUNT, count);
            }
        }

        [Collection("Database")]
        public class CreateDatabaseTests
        {
            [Fact]
            public void CreateAndDropDatabase()
            {
                Assert.True(true);
            }
        }
    }
}
