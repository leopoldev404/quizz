namespace QuizzService.Core.Questions;

public record Question(
    string? Id,
    string? Text,
    string[]? Options,
    string CorrectAnswer,
    DateTime? CreatedAt,
    string QuizId);