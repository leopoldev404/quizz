using Serilog;
using QuizzService.Core.Logging;
using MediatR;
using QuizzService.Core.Behaviors;
using QuizzService.Core;
using QuizzService.Infrastructure.Configurations;
using QuizzService.Core.Abstractions;
using QuizzService.Infrastructure.Questions;
using QuizzService.Infrastructure.Quizzes;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QuizzService.Core.Quizzes;
using QuizzService.Core.Questions;
using FluentValidation;

namespace QuizzService.Api;

public static class Extensions
{
    public static void AddLogger(this WebApplicationBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
            .Build();

        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);
        builder.Services.AddSingleton<Serilog.ILogger>(logger);
        builder.Services.AddSingleton<Core.Logging.ILogger, Logger>();
    }

    public static void AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ApplicationAssembly).Assembly));

        builder.Services.AddValidatorsFromAssemblyContaining<ApplicationAssembly>();

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
    }

    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<QuizzDatabaseSettings>(
            builder.Configuration.GetSection("QuizzDatabaseSettings"));

        builder.Services.AddSingleton<IQuizzesRepository>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<QuizzDatabaseSettings>>();

            var quizzesCollectionClient = new MongoClient(settings.Value.ConnectionString)
                .GetDatabase(settings.Value.Database)
                    .GetCollection<Quiz>(settings.Value.QuizzesCollectionName);

            return new QuizzesRepository(quizzesCollectionClient);
        });

        builder.Services.AddSingleton<IQuestionsRepository>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<QuizzDatabaseSettings>>();

            var questionsCollectionClient = new MongoClient(settings.Value.ConnectionString)
                .GetDatabase(settings.Value.Database)
                    .GetCollection<Question>(settings.Value.QuestionsCollectionName);

            return new QuestionsRepository(questionsCollectionClient);
        });
    }

    public static void AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy => policy
                    .WithOrigins("http://localhost:4000")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
    }
}