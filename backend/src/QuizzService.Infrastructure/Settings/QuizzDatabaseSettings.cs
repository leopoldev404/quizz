namespace QuizzService.Infrastructure.Configurations;

public record QuizzDatabaseSettings
{
    public string? ConnectionString { get; init; }
    public string? Database { get; init; }
    public string? QuestionsCollectionName { get; init; }
    public string? QuizzesCollectionName { get; init; }
    public string? TransactionsCollectionName { get; init; }
    public string? ScoresCollectionName { get; init; }
}