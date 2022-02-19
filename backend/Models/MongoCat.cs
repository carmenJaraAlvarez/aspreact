using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace backend.Models
{
    public class MongoCat
    {
        [BsonId]
        public ObjectId Id {get; set;}
        public int Height { get; set; }        
        public string? Url { get; set; }       
        public int Width { get; set; }
    }
}
