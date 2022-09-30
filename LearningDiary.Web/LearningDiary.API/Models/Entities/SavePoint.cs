using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LearningDiary.API.Models.Entities
{
    public record SavePoint
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SavePointId { get; init; }
        public DateTime DateOfCreation { get; init; } = DateTime.UtcNow;
        [BsonElement("Name")]
        public string Title { get; init; }
        public string Description { get; init; }
        public ICollection<string> Tags { get; init; }
        public string Result { get; init; }
        public TimeSpan TimeSpent { get; init; }

    }
}
