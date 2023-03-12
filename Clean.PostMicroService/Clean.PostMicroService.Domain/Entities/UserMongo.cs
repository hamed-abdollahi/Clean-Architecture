using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.PostMicroService.Domain.Entities
{
    public class UserMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
        [BsonElement("userId")]
        public int UserId { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("family")]
        public string? Family { get; set; }

        [BsonElement("posts")]
        public List<PostMongo> Posts = new List<PostMongo>();
    }
}
