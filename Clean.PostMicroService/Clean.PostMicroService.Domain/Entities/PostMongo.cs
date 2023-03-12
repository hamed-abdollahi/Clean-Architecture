using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.PostMicroService.Domain.Entities
{
    public class PostMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
        [BsonElement("postId")]
        public int PostId { get; set; }
        [BsonElement("title")]
        public string? Title { get; set; }
        [BsonElement("content")]
        public string? Content { get; set; }
        
    }
}
