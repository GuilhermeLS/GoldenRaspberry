using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace GoldenRaspberry.IntegrationTests
{
    public class ProducerControllerTests : TestBase
    {
        public ProducerControllerTests(WebApplicationFactory<GoldenRaspberryAwards.Startup> factory)
        : base(factory)
        {
        }

        [Fact]
        public async Task GetProducers_ShouldReturn_OK()
        {
            // Arrange
            var requestUrl = "/api/movies/producer-metrics";

            // Act
            var response = await _client.GetAsync(requestUrl);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotBeNullOrWhiteSpace();
        }

    }
}