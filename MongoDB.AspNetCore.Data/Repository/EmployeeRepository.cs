using MongoDB.AspNetCore.Data.SampleModel;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.AspNetCore.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MongoClient mongoClient = null;
        private IMongoDatabase mongoDatabase = null;
        private IMongoCollection<Employee> EmployeeTable = null;

        public EmployeeRepository()
        {
            //  mongoClient=new MongoClient("mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb");
            mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            mongoDatabase = mongoClient.GetDatabase("Northwind");
            EmployeeTable = mongoDatabase.GetCollection<Employee>("Emp");

        }
        public string Delete(string EmployeeId)
        {
            EmployeeTable.DeleteOne(x => x.Id == EmployeeId);
            return "Delete";
        }

        public Employee Get(string EmployeeId)
        {
            return EmployeeTable.Find(x => x.Id == EmployeeId).FirstOrDefault();
        }

        public List<Employee> Gets()
        {
            return EmployeeTable.Find(FilterDefinition<Employee>.Empty).ToList();
        }

        public Employee Save(Employee input)
        {
            var Employee=  EmployeeTable.Find(x => x.Id == input.Id ).FirstOrDefault();
            if (Employee==null)
            {
                EmployeeTable.InsertOne(input);
            }
            else
            {
                EmployeeTable.ReplaceOne(x=>x.Id== input.Id, input);
            }
            return input;
        }
    }
}
