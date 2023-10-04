using QuizzService.Core.Questions.Models;
using QuizzService.Core.Questions.Queries;

namespace QuizzService.Core.Abstractions;

public interface IQuestionsRepository
{
    ValueTask<List<Question>?> GetByQuizIdAsync(GetQuestionsByQuizIdQuery query, CancellationToken cancellationToken);
    ValueTask BulkInsertAsync(List<Question> question, CancellationToken cancellationToken);
}