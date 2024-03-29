﻿using FluentValidation;
using QuizzService.Api;
using QuizzService.Api.Exceptions;
using QuizzService.Api.Questions;
using QuizzService.Api.Quizzes;
using QuizzService.Api.Scores;
using QuizzService.Api.Transactions;
using QuizzService.Core;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
builder.Services.AddApplicationOptions();
builder.Services.AddMediator();
builder.Services.AddValidatorsFromAssemblyContaining<ApplicationAssembly>();
builder.Services.AddPipelineBehaviors();
builder.Services.AddRepositories();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDefaultCors();
builder.Services.AddHealthChecks();
builder.Services.AddTransient<ExceptionsHandlingMiddleware>();

var app = builder.Build();

app.MapQuestionsEndpoints();
app.MapQuizzesEndpoints();
app.MapScoresEndpoints();
app.MapTransactionsEndpoints();
app.MapHealthChecks("/ok");

app.UseCors();
app.UseMiddleware<ExceptionsHandlingMiddleware>();

await app.InitQuizzDbAsync();
await app.RunAsync();

public partial class Program { }