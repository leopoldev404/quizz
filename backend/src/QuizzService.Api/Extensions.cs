using Serilog;
using QuizzService.Core.Logging;
using MediatR;
using QuizzService.Core.Behaviors;
using QuizzService.Core;
using QuizzService.Infrastructure.Configurations;
using QuizzService.Core.Abstractions;
using QuizzService.Infrastructure.Questions;
using QuizzService.Infrastructure.Quizzes;

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
            cfg.RegisterServicesFromAssembly(typeof(MediatorAssembly).Assembly));

        builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    }

    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<QuizzDatabaseSettings>(
            builder.Configuration.GetSection("QuizzDatabaseSettings"));

        builder.Services.AddSingleton<IQuizzesRepository, QuizzesRepository>();
        builder.Services.AddSingleton<IQuestionsRepository, QuestionsRepository>();
    }
}