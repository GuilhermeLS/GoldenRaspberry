using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace GoldenRaspberry.IntegrationTests
{
    public class TestBase : IClassFixture<WebApplicationFactory<GoldenRaspberryAwards.Startup>>
    {
        protected readonly HttpClient _client;

        public TestBase(WebApplicationFactory<GoldenRaspberryAwards.Startup> factory)
        {
            _client = factory.CreateClient();
        }
    }
}
