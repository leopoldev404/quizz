using QuizzService.Core.Questions;
using QuizzService.Core.Questions.Queries;

namespace QuizzService.Core.Abstractions;

public interface IQuestionsRepository
{
    ValueTask<List<Question>?> FindByQuizIdAsync(GetQuestionsByQuizIdQuery query);
}