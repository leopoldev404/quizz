using MongoDB.Driver;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Quizzes;
using QuizzService.Core.Quizzes.Queries;

namespace QuizzService.Infrastructure.Quizzes;

public class QuizzesRepository : IQuizzesRepository
{
    private readonly IMongoCollection<Quiz> quizzesCollection;

    public QuizzesRepository(IMongoCollection<Quiz> quizzesCollection)
    {
        this.quizzesCollection = quizzesCollection;
    }

    public async ValueTask<Quiz?> FindByIdAsync(GetQuizByIdQuery query) =>
        await quizzesCollection.Find(quiz => quiz.Id == query.QuizId).FirstOrDefaultAsync();

    public async ValueTask<List<Quiz>?> FindAllAsync(GetQuizzesQuery query) =>
        await quizzesCollection.Find(_ => true).ToListAsync();
}