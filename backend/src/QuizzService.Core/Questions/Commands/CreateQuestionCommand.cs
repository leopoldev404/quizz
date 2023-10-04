using QuizzService.Core.Abstractions;
using QuizzService.Core.Questions.Models;

namespace QuizzService.Core.Questions.Commands;

public record CreateQuestionCommand(string Text, string[] Options, string CorrectAnswer) : ICommand<Question>;