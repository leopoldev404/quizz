using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Quizzes.Models;
using QuizzService.Core.Quizzes.Queries;
using QuizzService.Infrastructure.Configurations;

namespace QuizzService.Infrastructure.Quizzes;

public class QuizzesRepository : IQuizzesRepository
{
    private readonly IMongoCollection<Quiz> quizzesCollection;

    public QuizzesRepository(IMongoDatabase mongoDatabase, IOptions<QuizzDatabaseSettings> settings)
    {
        quizzesCollection = mongoDatabase
            .GetCollection<Quiz>(settings.Value.QuizzesCollectionName);
    }

    public async ValueTask<Quiz?> GetByIdAsync(
        string id,
        CancellationToken cancellationToken)
    {
        var filter = Builders<Quiz>.Filter
            .Eq(quiz => quiz.Id, id);

        var cursor = await quizzesCollection
            .FindAsync(filter: filter, cancellationToken: cancellationToken);

        return await cursor.SingleOrDefaultAsync(cancellationToken);
    }

    public async ValueTask<List<Quiz>?> GetAllWithPaginationAsync(
        GetQuizzesQuery query,
        CancellationToken cancellationToken)
    {
        var filter = Builders<Quiz>.Filter.Empty;

        var cursor = await quizzesCollection.FindAsync(
            filter,
            new FindOptions<Quiz, Quiz>
            {
                BatchSize = query.PageSize,
                Skip = query.PageNumber * query.PageSize,
            },
            cancellationToken);

        return await cursor.ToListAsync(cancellationToken);
    }

    public async ValueTask AddAsync(Quiz quizDocument) =>
        await quizzesCollection.InsertOneAsync(quizDocument);

    public async ValueTask<List<Quiz>?> GetAllAsync(GetQuizzesQuery query, CancellationToken cancellationToken)
    {
        var filter = Builders<Quiz>.Filter.Empty;

        return await quizzesCollection
            .Find(filter)
            .ToListAsync(cancellationToken);
    }
}