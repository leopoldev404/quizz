using QuizzService.Api;
using QuizzService.Api.Questions;
using QuizzService.Api.Quizzes;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
builder.AddMediator();
builder.AddRepositories();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapQuestionsEndpoints();
app.MapQuizzesEndpoints();
app.MapHealthChecks("/ok");

await app.RunAsync();