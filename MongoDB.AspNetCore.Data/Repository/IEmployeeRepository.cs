using MongoDB.AspNetCore.Data.SampleModel;
using System.Collections.Generic;

namespace MongoDB.AspNetCore.Data.Repository
{
    public interface IEmployeeRepository
    {
        Employee Save(Employee input);
        Employee Get(string EmployeeId);
        List<Employee> Gets();
        string Delete(string EmployeeId);
    }
}
