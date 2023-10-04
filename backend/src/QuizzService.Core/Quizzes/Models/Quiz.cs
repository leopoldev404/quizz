using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuizzService.Core.Quizzes.Models;

public record Quiz
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("category")]
    public string? Category { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("difficulty")]
    public string? Difficulty { get; set; }

    [BsonElement("tags")]
    public string[]? Tags { get; set; }

    [BsonElement("createdAt")]
    public DateTime? CreatedAt { get; set; }
}
