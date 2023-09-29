using MediatR;

namespace QuizzService.Core.Abstractions;

public interface ICommand<out TResponse> : IRequest<TResponse> { }