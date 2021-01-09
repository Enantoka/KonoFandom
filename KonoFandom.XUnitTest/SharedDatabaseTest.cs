/*using KonoFandom.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KonoFandom.XUnitTest
{
    public class SharedDatabaseTest : IClassFixture<SharedDatabaseFixture>
    {
        public SharedDatabaseTest(SharedDatabaseFixture fixture) => Fixture = fixture;

        public SharedDatabaseFixture Fixture { get; }

        [Fact]
        public void Can_get_item()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    var controller = new CharactersController(context);
                    var item = controller.GetCharacters();

                    Assert.Single(item.Result);
                }
            }
        }
    }
}
*/