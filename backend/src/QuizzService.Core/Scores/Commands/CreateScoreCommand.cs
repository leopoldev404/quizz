using QuizzService.Core.Abstractions;
using QuizzService.Core.Scores.Models;

namespace QuizzService.Core.Scores.Commands;

public record CreateScoreCommand(
    string Username,
    string QuizId,
    string ScoreValue) : ICommand<Score>;