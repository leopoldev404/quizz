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
using FluentValidation;
using QuizzService.Core.Quizzes.Commands;

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

    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ApplicationAssembly).Assembly));

        services.AddValidatorsFromAssemblyContaining<ApplicationAssembly>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<QuizzDatabaseSettings>(
            builder.Configuration.GetSection("QuizzDatabaseSettings"));

        builder.Services.AddSingleton<IMongoDatabase>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<QuizzDatabaseSettings>>();
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            return mongoClient.GetDatabase(settings.Value.Database);
        });

        builder.Services.AddSingleton<IQuizzesRepository, QuizzesRepository>();
        builder.Services.AddSingleton<IQuestionsRepository, QuestionsRepository>();
    }

    public static void AddDefaultCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy => policy
                    .WithOrigins("http://localhost:4000")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
    }

    public static async ValueTask InitQuizzDbAsync(this WebApplication app)
    {
        var sender = app.Services.GetRequiredService<ISender>();
        await sender.Send(new InitDbCommand());
    }
}