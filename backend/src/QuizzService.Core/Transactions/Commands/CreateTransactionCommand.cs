using QuizzService.Core.Abstractions;
using QuizzService.Core.Transactions.Models;

namespace QuizzService.Core.Transactions.Commands;

public record CreateTransactionCommand(
    string Username,
    string QuizId,
    string QuestionId,
    string GivenAnswer,
    bool IsCorrect) : ICommand<Transaction>;