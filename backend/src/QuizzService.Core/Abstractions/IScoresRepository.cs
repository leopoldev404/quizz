using QuizzService.Core.Scores;
using QuizzService.Core.Scores.Commands;

namespace QuizzService.Core.Abstractions;

public interface IScoresRepository
{
    ValueTask<Score> InsertAsync(CreateScoreCommand createScoreCommand);
}