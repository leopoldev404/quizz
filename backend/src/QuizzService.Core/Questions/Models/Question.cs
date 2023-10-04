
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuizzService.Core.Questions.Models;

public record Question
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("text")]
    public string? Text { get; set; }

    [BsonElement("options")]
    public string[]? Options { get; set; }

    [BsonElement("correctAnswer")]
    public string? CorrectAnswer { get; set; }

    [BsonElement("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [BsonElement("quizId")]
    public string? QuizId { get; set; }
}

