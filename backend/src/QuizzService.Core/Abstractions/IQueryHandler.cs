using MediatR;

namespace QuizzService.Core.Abstractions;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse?>
    where TQuery : IQuery<TResponse?>
{ }