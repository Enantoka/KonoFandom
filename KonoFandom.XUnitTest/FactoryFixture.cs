using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KonoFandom.XUnitTest
{
    // Fixture to be shared between all test classes
    public class FactoryFixture : IClassFixture<CustomWebApplicationFactory<TestStartup>>
    {
        public FactoryFixture(CustomWebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        public WebApplicationFactory<TestStartup> _factory { get; }
    }
}
