using MongoDB.AspNetCore.Data.SampleModel;
using System.Collections.Generic;

namespace MongoDB.AspNetCore.Data.Core
{
    public interface ICategoryCore
    {
        Category Save(Category input);
        Category Get(string CategoryId);
        List<Category> Gets();
        string Delete(string CategoryId);
    }
}
