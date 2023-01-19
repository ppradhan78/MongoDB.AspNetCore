using MongoDB.AspNetCore.Data.SampleModel;
using System.Collections.Generic;

namespace MongoDB.AspNetCore.Data.Core
{
    public interface IEmployeeCore
    {
        Employee Save(Employee input);
        Employee Get(string EmployeeId);
        List<Employee> Gets();
        string Delete(string EmployeeId);
    }
}
