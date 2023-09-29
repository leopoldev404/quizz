using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Quizzes;
using QuizzService.Core.Quizzes.Queries;
using QuizzService.Infrastructure.Configurations;

namespace QuizzService.Infrastructure.Quizzes;

public class QuizzesRepository : IQuizzesRepository
{
    private readonly IMongoCollection<Quiz> quizzesCollection;

    public QuizzesRepository(IOptions<QuizzDatabaseSettings> settings)
    {
        quizzesCollection = new MongoClient(settings.Value.ConnectionString)
            .GetDatabase(settings.Value.Database)
                .GetCollection<Quiz>(settings.Value.QuestionsCollectionName);
    }

    public async ValueTask<Quiz> FindByIdAsync(GetQuizByIdQuery query) =>
        await quizzesCollection.Find(quiz => quiz.Id == query.QuizId).FirstOrDefaultAsync();

    public async ValueTask<List<Quiz>> FindAllAsync(GetQuizzesQuery query) =>
        await quizzesCollection.Find(_ => true).ToListAsync();
}