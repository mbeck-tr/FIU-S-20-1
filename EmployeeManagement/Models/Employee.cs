using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        //void Save(EmployeeDemo employee);
    }

    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id = 1, Name = "Mary", Department="HR"},
                new Employee(){Id = 2, Name = "John", Department="IT"},
                new Employee(){Id = 3, Name = "Sam", Department="IT"}
            };
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }
    }

    public class TestRepo : IEmployeeRepository
    {
        public Employee GetEmployee(int ident)
        {
            return new Employee() { Id = 111, Name = "Michael", Department = "IT" };
        }
    }
}
