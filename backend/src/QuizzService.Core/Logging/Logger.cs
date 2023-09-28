namespace QuizzService.Core.Logging;

public class Logger : ILogger
{
    private readonly Serilog.ILogger logger;

    public Logger(Serilog.ILogger logger)
    {
        this.logger = logger;
    }

    public void LogDebug(string message) =>
        logger.Debug(message);

    public void LogInformation(string message) =>
        logger.Information(message);

    public void LogWarning(string message) =>
        logger.Warning(message);

    public void LogError(string message) =>
        logger.Error(message);
}