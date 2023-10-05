using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Transactions.Models;
using QuizzService.Infrastructure.Configurations;

namespace QuizzService.Infrastructure.Transactions
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly IMongoCollection<Transaction> scoresCollection;

        public TransactionsRepository(
            IMongoDatabase mongoDatabase,
            IOptions<QuizzDatabaseSettings> settings)
        {
            scoresCollection = mongoDatabase
                .GetCollection<Transaction>(settings.Value.TransactionsCollectionName);
        }

        public async ValueTask InsertAsync(Transaction transaction) =>
            await scoresCollection.InsertOneAsync(transaction);
    }
}