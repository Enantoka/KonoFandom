﻿using KonoFandom.Areas.Admin.Data;
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
using System.IO;

namespace KonoFandom.XUnitTest
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

            services.AddDbContext<KonoFandomContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("TestApplicationDb"))
           .UseSnakeCaseNamingConvention());

            services.AddDbContext<IdentityContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("TestUserDb"))
            .UseSnakeCaseNamingConvention());

            services.AddIdentity<KonoFandomUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
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
                SeedData.Intialize(serviceProvider);
            }
            
        }
    }
}
