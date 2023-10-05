using QuizzService.Core.Abstractions;
using QuizzService.Core.Transactions.Models;

namespace QuizzService.Core.Transactions.Commands;

public sealed class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand, Transaction>
{
    private readonly ITransactionsRepository transactionsRepository;

    public CreateTransactionCommandHandler(ITransactionsRepository transactionsRepository)
    {
        this.transactionsRepository = transactionsRepository;
    }

    public async Task<Transaction?> Handle(
        CreateTransactionCommand command,
        CancellationToken cancellationToken)
    {
        var transaction = new Transaction
        {
            QuizId = command.QuizId,
            UserName = command.Username,
            QuestionId = command.QuestionId,
            GivenAnswer = command.GivenAnswer,
            AnswerIsCorrect = command.IsCorrect,
            EventTime = DateTime.UtcNow
        };

        await transactionsRepository.InsertAsync(transaction);
        return transaction;
    }
}