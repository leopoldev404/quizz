using QuizzService.Api;
using QuizzService.Api.Questions;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
builder.AddMediator();
builder.AddRepositories();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/ok");
app.MapQuestionsEndpoints();

await app.RunAsync();