using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.AspNetCore.Data.SampleModel
{
    public class Category
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }
}
