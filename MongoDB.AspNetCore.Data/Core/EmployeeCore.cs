using MongoDB.AspNetCore.Data.Repository;
using MongoDB.AspNetCore.Data.SampleModel;
using System.Collections.Generic;

namespace MongoDB.AspNetCore.Data.Core
{
    public class EmployeeCore : IEmployeeCore
    {
        IEmployeeRepository _EmployeeRepository;

        public EmployeeCore(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }
        public string Delete(string EmployeeId)
        {
           return _EmployeeRepository.Delete(EmployeeId);
        }

        public Employee Get(string EmployeeId)
        {
           return _EmployeeRepository.Get(EmployeeId);
        }

        public List<Employee> Gets()
        {
            return _EmployeeRepository.Gets();  
        }

        public Employee Save(Employee input)
        {
            return _EmployeeRepository.Save(input);
        }
    }
}
