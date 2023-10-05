using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Scores.Models;
using QuizzService.Infrastructure.Configurations;

namespace QuizzService.Infrastructure.Scores;

public class ScoresRepository : IScoresRepository
{
    private readonly IMongoCollection<Score> scoresCollection;

    public ScoresRepository(
        IMongoDatabase mongoDatabase,
        IOptions<QuizzDatabaseSettings> settings)
    {
        scoresCollection = mongoDatabase
            .GetCollection<Score>(settings.Value.ScoresCollectionName);
    }

    public async ValueTask InsertAsync(Score score) =>
        await scoresCollection.InsertOneAsync(score);
}