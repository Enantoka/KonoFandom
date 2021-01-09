using System;
using DoomedDatabases.Postgres;
using Xunit;
using Microsoft.Extensions.Configuration;
using KonoFandom.Data;
using Microsoft.EntityFrameworkCore;
using KonoFandom.Models;
using System.Linq;

namespace KonoFandom.XUnitTest
{
    public class SharedDatabaseFixture : IDisposable
    {
        private readonly ITestDatabase TestDatabase;

        public SharedDatabaseFixture()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            TestDatabase = new TestDatabaseBuilder().WithConfiguration(configuration).Build();
            TestDatabase.Create();

            var builder = new DbContextOptionsBuilder<KonoFandomContext>();
            builder.UseNpgsql(TestDatabase.ConnectionString);
            DbContext = new KonoFandomContext(builder.Options);
            DbContext.Database.EnsureCreated();

            Seed();
        }

        public KonoFandomContext DbContext { get; }

        private void Seed()
        {
            DbContext.Character.AddRange(
                new Character
                {
                    Name = "Kazuma",
                    CharacterVoice = "Fukushima Jun",
                    Birthday = new DateTime(2020, 6, 7),
                    Biography = "A boy reincarnated from Japan who originally was a shut-in " +
                    "that loves games. He has the worst job - an adventurer, but with his high " +
                    "luck stats, quick-wittedness and strength of his comrades he stands evenly " +
                    "matched when contending against the Demon Army Generals.",
                    IconImagePath = "https://drive.google.com/uc?export=view&id=1fImzqGmYvNJwpq1f2XdokNHttKhzLdUC",
                    CharacterImagePath = "https://drive.google.com/uc?export=view&id=1ZPreciFaaJ_aZ8G16uL6kvrgFFyAcfZS"
                }
            );
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            TestDatabase.Drop();
        }
    }
}
