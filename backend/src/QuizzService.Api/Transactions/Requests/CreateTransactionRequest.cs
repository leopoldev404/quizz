namespace QuizzService.Api.Transactions.Requests;

public record CreateTransactionRequest(
    string QuizId,
    string UserName,
    string QuestionId,
    string GivenAnswer,
    bool AnswerIsCorrect);