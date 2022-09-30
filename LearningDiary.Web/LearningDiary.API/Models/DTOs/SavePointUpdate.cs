﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace LearningDiary.API.Models.DTOs
{
    public class SavePointUpdate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SavePointId { get; set; }
        [Required]
        [MinLength(3), MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public ICollection<string> Tags { get; set; }
        [Required]
        [MinLength(3), MaxLength(100)]
        public string Result { get; set; }
        [Required]
        public TimeSpan TimeSpent { get; set; }
    }
}
