using QuizzService.Core.Abstractions;

namespace QuizzService.Core.Transactions.Commands;

public record CreateTransactionCommand(
    string Username,
    string QuizId,
    string QuestionId) : ICommand<Transaction>;