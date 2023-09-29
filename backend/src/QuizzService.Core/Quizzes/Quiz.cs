namespace QuizzService.Core.Quizzes;

public record Quiz(
    string? Id,
    string? Name,
    string? Category,
    string? Description,
    DateTime? CreatedAt
);
