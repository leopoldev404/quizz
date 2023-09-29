using QuizzService.Core.Abstractions;

namespace QuizzService.Core.Quizzes.Queries;

public record GetQuizByIdQuery(string QuizId) : IQuery<Quiz>;