using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.AspNetCore.Data.SampleModel
{
    public class Employee
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Empno { get; set; }
        public string ename { get; set; }
        public string job { get; set; }
        public string mgr { get; set; }
        public string hiredate { get; set; }
        public string sal { get; set; }
        public string comm { get; set; }
        public string deptno { get; set; }
        public byte[] Photo { get; set; }
    }
}
