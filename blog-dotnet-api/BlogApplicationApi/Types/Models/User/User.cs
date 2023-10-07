using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Types.Models.User
{
    // public class User
    // {
    //     [BsonId]
    //     [BsonRepresentation(BsonType.ObjectId)]
    //     public int Id { get; set; }

    //     [BsonElement("Name")]
    //     public string Name { get; set; } = string.Empty;
    //     public string Email { get; set; } = string.Empty;
    // }

    public class User
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public AddressInfo? Address { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public CompanyInfo? Company { get; set; }

    }
}
