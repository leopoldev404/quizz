using MediatR;

namespace QuizzService.Core.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse>
{

}