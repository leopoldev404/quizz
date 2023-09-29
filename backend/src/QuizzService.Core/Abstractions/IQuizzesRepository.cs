using QuizzService.Core.Quizzes;
using QuizzService.Core.Quizzes.Queries;

namespace QuizzService.Core.Abstractions;

public interface IQuizzesRepository
{
    ValueTask<Quiz> FindByIdAsync(GetQuizByIdQuery query);
    ValueTask<List<Quiz>> FindAllAsync(GetQuizzesQuery query);
}