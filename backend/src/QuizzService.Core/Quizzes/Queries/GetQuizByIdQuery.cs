using MediatR;

namespace QuizzService.Core.Quizzes.Queries;

public record GetQuizByIdQuery(string QuizId) : IRequest<Quiz>;