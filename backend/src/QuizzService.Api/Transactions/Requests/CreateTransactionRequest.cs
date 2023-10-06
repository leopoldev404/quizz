using System.Text.Json.Serialization;

namespace QuizzService.Api.Transactions.Requests;

public record CreateTransactionRequest(
    [property: JsonPropertyName("quizId")] string QuizId,
    [property: JsonPropertyName("username")] string UserName,
    [property: JsonPropertyName("questionId")] string QuestionId,
    [property: JsonPropertyName("givenAnswer")] string GivenAnswer,
    [property: JsonPropertyName("answerIsCorrect")] bool AnswerIsCorrect);