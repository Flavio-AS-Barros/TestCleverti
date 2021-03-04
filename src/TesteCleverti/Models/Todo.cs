using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TesteCleverti.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TodoId { get; set; }

        [BsonRequired]
        public string Title { get; set; }
                
        public String Description { get; set; }

        public bool Completed { get; set; } = false;

        public DateTime DueDate { get; set; }
      
    }
}
