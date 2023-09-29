using QuizzService.Core.Abstractions;

namespace QuizzService.Core.Quizzes.Queries;

public record GetQuizzesQuery(
    int PageSize,
    int PageNumber) : IQuery<List<Quiz>>;

