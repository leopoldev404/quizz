using QuizzService.Core.Abstractions;

namespace QuizzService.Core.Scores.Commands;

public record CreateScoreCommand() : ICommand<Score>;