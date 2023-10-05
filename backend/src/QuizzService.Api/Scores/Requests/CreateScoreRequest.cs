namespace QuizzService.Api.Scores.Requests;
public record CreateScoreRequest(
    string? Username,
    string? QuizId,
    string? ScoreValue);