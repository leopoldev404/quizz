using QuizzService.Core.Scores.Models;

namespace QuizzService.Core.Abstractions;

public interface IScoresRepository
{
    ValueTask InsertAsync(Score score);
}