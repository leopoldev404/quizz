using MediatR;

namespace QuizzService.Core.Questions.Queries;

public record GetQuestionsByQuizIdQuery(
    string QuizId,
    int PageNumber,
    int PageSize) : IRequest<List<Question>>;