using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Questions;
using QuizzService.Core.Questions.Queries;
using QuizzService.Infrastructure.Configurations;

namespace QuizzService.Infrastructure.Questions;
public class QuestionsRepository : IQuestionsRepository
{
    private readonly IMongoCollection<Question> questionsCollection;

    public QuestionsRepository(IOptions<QuizzDatabaseSettings> settings)
    {
        questionsCollection = new MongoClient(settings.Value.ConnectionString)
            .GetDatabase(settings.Value.Database)
                .GetCollection<Question>(settings.Value.QuestionsCollectionName);
    }

    public async ValueTask<List<Question>> FindQuestionsByQuizIdAsync(GetQuestionsByQuizIdQuery query)
        => await questionsCollection.Find(question => question.QuizId == query.QuizId).ToListAsync();
}