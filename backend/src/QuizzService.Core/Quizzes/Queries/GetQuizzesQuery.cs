using MediatR;

namespace QuizzService.Core.Quizzes.Queries;

public record GetQuizzesQuery(
    int PageSize,
    int PageNumber) : IRequest<List<Quiz>>;

