using MediatR;
using QuizzService.Core.Logging;

namespace QuizzService.Core.Behaviors;

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
        logger.LogInformation($"Handled {typeof(TRequest).Name}");
        return response;
    }
}