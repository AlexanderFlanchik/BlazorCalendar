using MongoDB.Bson.Serialization.Attributes;

namespace BlazorCalendar.Domain
{
    public abstract class EntityBase
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public required string Id { get; set; }
    }
}