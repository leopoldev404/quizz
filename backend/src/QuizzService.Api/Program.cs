using QuizzService.Api;
using QuizzService.Api.Exceptions;
using QuizzService.Api.Questions;
using QuizzService.Api.Quizzes;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
builder.Services.AddMediator();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDefaultCors();
builder.Services.AddHealthChecks();
builder.AddRepositories();
builder.Services.AddTransient<ExceptionsHandlingMiddleware>();

var app = builder.Build();

app.MapQuestionsEndpoints();
app.MapQuizzesEndpoints();
app.MapHealthChecks("/ok");

app.UseCors();
app.UseMiddleware<ExceptionsHandlingMiddleware>();

await app.InitQuizzDbAsync();
await app.RunAsync();

public partial class Program { }