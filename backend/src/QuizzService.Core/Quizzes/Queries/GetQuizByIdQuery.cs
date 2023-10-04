using QuizzService.Core.Abstractions;
using QuizzService.Core.Quizzes.Models;

namespace QuizzService.Core.Quizzes.Queries;

public record GetQuizByIdQuery(string QuizId) : IQuery<Quiz>;