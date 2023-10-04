using QuizzService.Core.Transactions;
using QuizzService.Core.Transactions.Commands;

namespace QuizzService.Core.Abstractions;

public interface ITransactionsRepository
{
    ValueTask<Transaction> InsertAsync(CreateTransactionCommand createTransactionCommand);
}