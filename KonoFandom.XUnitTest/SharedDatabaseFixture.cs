using System;
using DoomedDatabases.Postgres;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace KonoFandom.XUnitTest
{
    public class SharedDatabaseFixture : IDisposable
    {
        private readonly ITestDatabase testDatabase;

        public SharedDatabaseFixture()
        {
            var connectionString = "Host=localhost;Database=test;Username=postgres;Password=admin";
            testDatabase = new TestDatabaseBuilder().WithConnectionString(connectionString).Build();
            testDatabase.Create();
        }

        [CollectionDefinition("Database")]
        public class DatabaseCollectionFixture : ICollectionFixture<SharedDatabaseFixture>
        {

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

        public void Dispose()
        {
            testDatabase.Drop();
        }
    }
}
