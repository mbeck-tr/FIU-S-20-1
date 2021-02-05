using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bitte Name angeben!")]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="Invalid email format")]
        [Display(Name="Office Email")]
        public string Email { get; set; }

        [Required]
        public Dept? Department { get; set; }
    }

    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();
        Employee Add(Employee employee);
    }

    public class MockEmployeeRepository : IEmployeeRepository
    {
        //Felder
        private List<Employee> _employeeList;

        //Konstruktor
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id = 1, Name = "Mary", Department=Dept.HR, Email="mary@example.com"},
                new Employee(){Id = 2, Name = "John", Department=Dept.IT, Email="john@example.com"},
                new Employee(){Id = 3, Name = "Sam", Department=Dept.IT, Email="sam@example.com"}
            };
        }

        //Methoden
        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee Add(Employee employee)
        {
            int maxId = 0;
            //for (int i = 0; i < _employeeList.Count; i++)
            //{
            //    if (_employeeList[i].Id > maxId) maxId = _employeeList[i].Id;
            //}
            foreach (var item in _employeeList)
            {
                if (item.Id > maxId) maxId = item.Id;
            }
            employee.Id = maxId + 1;

            employee.Id = _employeeList.Max(e => e.Id) + 1;

            _employeeList.Add(employee);

            return employee;
        }
    }


    public class DBEmployeeRepository : IEmployeeRepository
    {
        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int ident)
        {
            return new Employee() { Id = 111, Name = "Michael", Department = Dept.IT };
        }
    }
}
