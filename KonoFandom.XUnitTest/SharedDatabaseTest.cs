using KonoFandom.Controllers;
using KonoFandom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public class CharacterTests
        {
            private SharedDatabaseFixture fixture;

            public CharacterTests(SharedDatabaseFixture fixture)
            {
                this.fixture = fixture;
            }

            [Fact]
            public void Get_amount_of_characters()
            {
                var count = fixture.DbContext.Character.Count();
                Assert.Equal(2, count);
            }

            [Fact]
            public void Add_characters()
            {
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
                var count = fixture.DbContext.Character.Count();
                Assert.Equal(2, count);
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
