using MongoDB.AspNetCore.Data.SampleModel;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.AspNetCore.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private MongoClient mongoClient = null;
        private IMongoDatabase mongoDatabase = null;
        private IMongoCollection<Category> categoryTable = null;

        public CategoryRepository()
        {
            //  mongoClient=new MongoClient("mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb");
            mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            mongoDatabase = mongoClient.GetDatabase("Northwind");
            categoryTable = mongoDatabase.GetCollection<Category>("Categories");

        }
        public string Delete(string CategoryId)
        {
            categoryTable.DeleteOne(x => x.Id == CategoryId);
            return "Delete";
        }

        public Category Get(string CategoryId)
        {
            return categoryTable.Find(x => x.Id == CategoryId).FirstOrDefault();
        }

        public List<Category> Gets()
        {
            return categoryTable.Find(FilterDefinition<Category>.Empty).ToList();
        }

        public Category Save(Category input)
        {
            var category=  categoryTable.Find(x => x.Id == input.Id ).FirstOrDefault();
            if (category==null)
            {
                categoryTable.InsertOne(input);
            }
            else
            {
                categoryTable.ReplaceOne(x=>x.Id== input.Id, input);
            }
            return input;
        }
    }
}
