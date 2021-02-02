using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeDemo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    public interface IEmployeeRepositoryDemo
    {
        EmployeeDemo GetEmployee(int id);
        void Save(EmployeeDemo employee);
    }

    public class EmployeeRepository : IEmployeeRepositoryDemo
    {
        public EmployeeDemo GetEmployee(int id)
        {
            //Logic to retrieve employee details
            throw new NotImplementedException();
        }

        public void Save(EmployeeDemo employee)
        {
            //Logic to save employee details
        }
    }
}
