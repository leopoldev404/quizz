using QuizzService.Api;
using QuizzService.Api.Exceptions;
using QuizzService.Api.Questions;
using QuizzService.Api.Quizzes;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
builder.AddMediator();
builder.AddRepositories();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHealthChecks();
builder.Services.AddTransient<ExceptionsHandlingMiddleware>();
builder.AddCors();

var app = builder.Build();

app.MapQuestionsEndpoints();
app.MapQuizzesEndpoints();
app.MapHealthChecks("/ok");

app.UseCors();
app.UseMiddleware<ExceptionsHandlingMiddleware>();

await app.RunAsync();

public partial class Program { }