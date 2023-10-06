using System.Text.Json.Serialization;

namespace QuizzService.Api.Scores.Requests;

public record CreateScoreRequest(
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("quizId")] string QuizId,
    [property: JsonPropertyName("score")] int ScoreValue);