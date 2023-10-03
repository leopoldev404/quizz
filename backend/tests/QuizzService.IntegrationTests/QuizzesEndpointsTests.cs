using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace QuizzService.IntegrationTests;

public class QuizzesEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient httpClient;

    public QuizzesEndpointsTests(WebApplicationFactory<Program> webApplicationFactory)
    {
        httpClient = webApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task ReturnQuizzes()
    {
        HttpResponseMessage response = await httpClient.GetAsync("api/quizzes");
        string responseContent = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotEmpty(responseContent);
    }

    [Theory]
    [InlineData("573a1398f29313caabce9682")]
    public async Task WhenQuizIdIsValidButNotFoundReturnNotFound(string quizId)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"/{quizId}");
        string responseContent = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.NotEmpty(responseContent);
    }

    [Theory]
    [InlineData("tf32f4tf23f4")]
    public async Task WhenQuizIdIsNotValidReturnBadRequest(string quizId)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"api/quizzes/{quizId}");
        string responseContent = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.NotEmpty(responseContent);
    }

}