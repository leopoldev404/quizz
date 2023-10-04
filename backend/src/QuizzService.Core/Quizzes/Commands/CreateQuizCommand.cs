using QuizzService.Core.Abstractions;
using QuizzService.Core.Quizzes.Models;

namespace QuizzService.Core.Quizzes.Commands;

public record CreateQuizCommand(
    string Name,
    string Category,
    string? Description,
    string? Difficulty,
    string[]? Tags) : ICommand<Quiz>;