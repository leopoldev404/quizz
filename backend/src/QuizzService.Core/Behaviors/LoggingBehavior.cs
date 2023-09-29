namespace QuizzService.Core.Behaviors;

using MediatR;
using QuizzService.Core.Logging;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger logger;

    public LoggingBehavior(ILogger logger) =>
        this.logger = logger;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Handling {typeof(TRequest).Name} - {request}");
        var response = await next();
        logger.LogInformation($"Finished Handling {typeof(TResponse).Name}");
        return response;
    }
}