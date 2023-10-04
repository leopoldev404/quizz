using QuizzService.Core.Abstractions;

namespace QuizzService.Core.Quizzes.Commands;

public record InitDbCommand() : ICommand<bool>;