using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuizzService.Core.Transactions;

public record Transaction
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("quizId")]
    public string? QuizId { get; set; }

    [BsonElement("questionId")]
    public string? QuestionId { get; set; }

    [BsonElement("userName")]
    public string? UserName { get; set; }

    [BsonElement("givenAnswer")]
    public string? GivenAnswer { get; set; }

    [BsonElement("answerIsCorrect")]
    public bool? AnswerIsCorrect { get; set; }

    [BsonElement("eventTime")]
    public DateTime? EventTime { get; set; }
}