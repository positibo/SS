using Moq;
using SS.CodingChallenge.Api.Source.Domain.Models;
using SS.CodingChallenge.Api.Source.Infrastructure.Data;

namespace SS.CodingChallenge.Tests
{
    public class AuthenticateTests
    {
        [Fact]
        public async Task Authenticat()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();
            var apiClient = new SmartSearchApi(mockHttpClient.Object);

            // Mock a successful response
            //var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            //{
            //    Content = new StringContent("{\"access_token\":\"abcdef1234567890\"}")
            //};

            //mockHttpClient.Setup(client => client.PostAsync(It.IsAny<Account>(), It.IsAny<HttpContent>()))
            //    .ReturnsAsync(mockResponse);

            // Act
            var result = await apiClient.AuthenticateAsync();

            // Assert
            Assert.NotNull(result);
            //Assert.Contains("abcdef1234567890", result);
        }
    }
}