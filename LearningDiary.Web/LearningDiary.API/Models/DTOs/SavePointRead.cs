using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LearningDiary.API.Models.DTOs
{
    public class SavePointRead
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SavePointId { get; set; }
        public DateTime DateOfCreation { get; set; }
        [BsonElement("Name")]
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<string> Tags { get; set; }
        public string Result { get; set; }
        public TimeSpan TimeSpent { get; set; }
    }
}
