using KonoFandom.Areas.Admin.Data;
using KonoFandom.Areas.Admin.Models;
using KonoFandom.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace KonoFandom.Testing
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration) {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            // Utilise appsettings.json in test project
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            /* Add database context with connection string to test databases
             * to services
             */
            services.AddDbContext<KonoFandomContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("TestApplicationDb"))
           .UseSnakeCaseNamingConvention());

            services.AddDbContext<IdentityContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("TestUserDb"))
            .UseSnakeCaseNamingConvention());

            services.AddIdentity<KonoFandomUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddEntityFrameworkStores<IdentityContext>();
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);

            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                var testDbContext = serviceProvider.GetRequiredService<KonoFandomContext>();

                // Create the test application database
                testDbContext.Database.EnsureCreated();

                // Seed test application database
                try
                {
                    Utility.Intialize(serviceProvider);
                }
                catch (Exception ex)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB");
                }
            }
        }
    }
}
