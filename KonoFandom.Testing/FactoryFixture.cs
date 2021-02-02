using KonoFandom.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Xunit;

namespace KonoFandom.Testing
{
    // Fixture to be shared between all test classes
    public class FactoryFixture : IClassFixture<CustomWebApplicationFactory<TestStartup>>
    {
        //private IAsyncActionFilter filter;

        public FactoryFixture(CustomWebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        public WebApplicationFactory<TestStartup> _factory { get; }
    }
}
