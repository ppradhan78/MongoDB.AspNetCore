using MongoDB.AspNetCore.Data.Repository;
using MongoDB.AspNetCore.Data.SampleModel;
using System.Collections.Generic;

namespace MongoDB.AspNetCore.Data.Core
{
    public class CategoryCore : ICategoryCore
    {
        ICategoryRepository _categoryRepository;

        public CategoryCore(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public string Delete(string CategoryId)
        {
           return _categoryRepository.Delete(CategoryId);
        }

        public Category Get(string CategoryId)
        {
           return _categoryRepository.Get(CategoryId);
        }

        public List<Category> Gets()
        {
            return _categoryRepository.Gets();  
        }

        public Category Save(Category input)
        {
            return _categoryRepository.Save(input);
        }
    }
}
