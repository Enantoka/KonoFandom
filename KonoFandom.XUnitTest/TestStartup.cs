using KonoFandom.Areas.Admin.Data;
using KonoFandom.Areas.Admin.Models;
using KonoFandom.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace KonoFandom.XUnitTest
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration) {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<KonoFandomContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
           .UseSnakeCaseNamingConvention());

            services.AddDbContext<IdentityContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
            .UseSnakeCaseNamingConvention());

            services.AddIdentity<KonoFandomUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddEntityFrameworkStores<IdentityContext>();
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);

            /* var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var testDbContext = serviceScope.ServiceProvider.GetRequiredService<KonoFandomContext>();
                Console.WriteLine("TEST STRING > > > > : " + testDbContext.Database.GetDbConnection().ConnectionString.ToLower());
                testDbContext.Database.EnsureCreated();
            }*/
            
        }
    }
}
