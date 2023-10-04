using QuizzService.Core.Quizzes.Models;
using QuizzService.Core.Quizzes.Queries;

namespace QuizzService.Core.Abstractions;

public interface IQuizzesRepository
{
    ValueTask AddAsync(Quiz quizDocument);
    ValueTask<Quiz?> GetByIdAsync(string id, CancellationToken cancellationToken);
    ValueTask<List<Quiz>?> GetAllWithPaginationAsync(GetQuizzesQuery query, CancellationToken cancellationToken);
    ValueTask<List<Quiz>?> GetAllAsync(GetQuizzesQuery query, CancellationToken cancellationToken);
}