using QuizzService.Core.Transactions.Models;

namespace QuizzService.Core.Abstractions;

public interface ITransactionsRepository
{
    ValueTask InsertAsync(Transaction transaction);
}