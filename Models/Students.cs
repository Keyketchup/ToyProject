using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentManager.Models
{
    public class Students
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{ get; set;}

        [BsonElement("Name")]
        public string Name{ get; set;}

        [BsonElement("Code")]
        public string Code{ get; set;}
    }
}