using QuizzService.Core.Abstractions;
using QuizzService.Core.Quizzes.Models;

namespace QuizzService.Core.Quizzes.Queries;

public record GetQuizzesQuery(
    int PageSize,
    int PageNumber) : IQuery<List<Quiz>>;

