using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuizzService.Core.Scores;

public record Score
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("quizId")]
    public string? QuizId { get; set; }

    [BsonElement("username")]
    public string? Username { get; set; }

    [BsonElement("score")]
    public string? ScoreValue { get; set; }
}