using QuizzService.Core.Abstractions;
using QuizzService.Core.Scores.Models;

namespace QuizzService.Core.Scores.Commands;

public sealed class CreateScoreCommandHandler : ICommandHandler<CreateScoreCommand, Score>
{
    private readonly IScoresRepository scoresRepository;

    public CreateScoreCommandHandler(IScoresRepository scoresRepository)
    {
        this.scoresRepository = scoresRepository;
    }

    public async Task<Score?> Handle(
        CreateScoreCommand command,
        CancellationToken cancellationToken)
    {
        var score = new Score
        {
            QuizId = command.QuizId,
            ScoreValue = command.ScoreValue,
            Username = command.Username,
            ScoreDate = DateTime.UtcNow
        };

        await scoresRepository.InsertAsync(score);
        return score;
    }
}