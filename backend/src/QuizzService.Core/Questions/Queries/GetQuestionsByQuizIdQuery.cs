using QuizzService.Core.Abstractions;
using QuizzService.Core.Questions.Models;

namespace QuizzService.Core.Questions.Queries;

public record GetQuestionsByQuizIdQuery(
    string QuizId,
    int PageNumber,
    int PageSize) : IQuery<List<Question>>;