using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Types.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}