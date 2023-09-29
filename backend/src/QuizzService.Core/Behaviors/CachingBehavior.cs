
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Logging;

namespace QuizzService.Core.Behaviors;
public sealed class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IQuery<TResponse>
{
    private readonly ILogger logger;
    private readonly IDistributedCache distributedCache;

    public CachingBehavior(
        IDistributedCache distributedCache,
        ILogger logger)
    {
        this.distributedCache = distributedCache;
        this.logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var cacheKey = $"{typeof(TRequest).Name}-{JsonSerializer.Serialize(request)}";
        var cachedResult = await distributedCache.GetStringAsync(cacheKey, cancellationToken);

        if (!string.IsNullOrWhiteSpace(cachedResult))
        {
            logger.LogInformation($"Request retrieved from Cache");
            return JsonSerializer.Deserialize<TResponse>(cachedResult)!;
        }

        var response = await next();

        if (response is not null)
        {
            logger.LogInformation($"Caching {typeof(TRequest).Name}-{JsonSerializer.Serialize(request)}");
            await distributedCache.SetStringAsync(
                cacheKey,
                JsonSerializer.Serialize(response),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                },
                cancellationToken);
        }

        return response;
    }
}