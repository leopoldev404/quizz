using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace QuizzService.IntegrationTests;

public class QuizzesEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient httpClient;

    public QuizzesEndpointsTests(WebApplicationFactory<Program> webApplicationFactory)
    {
        httpClient = webApplicationFactory.CreateClient();
    }
}