using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Questions.Models;
using QuizzService.Core.Questions.Queries;
using QuizzService.Infrastructure.Configurations;

namespace QuizzService.Infrastructure.Questions;

public class QuestionsRepository : IQuestionsRepository
{
    private readonly IMongoCollection<Question> questionsCollection;

    public QuestionsRepository(
        IMongoDatabase mongoDatabase,
        IOptions<QuizzDatabaseSettings> settings)
    {
        questionsCollection = mongoDatabase
            .GetCollection<Question>(settings.Value.QuestionsCollectionName);
    }

    public async ValueTask<List<Question>?> GetByQuizIdAsync(
        GetQuestionsByQuizIdQuery query,
        CancellationToken cancellationToken)
    {
        var filter = Builders<Question>.Filter
            .Eq(question => question.QuizId, query.QuizId);

        return await questionsCollection.Find(filter).ToListAsync(cancellationToken);
    }

    public async ValueTask BulkInsertAsync(
        List<Question> questions,
        CancellationToken cancellationToken) =>
            await questionsCollection.InsertManyAsync(questions, cancellationToken: cancellationToken);

}