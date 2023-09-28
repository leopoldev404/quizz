using QuizzService.Api;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/ok");

await app.RunAsync();