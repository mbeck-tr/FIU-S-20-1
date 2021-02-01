using EmployeeManagement.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagement.Controller
{
    public class EmployeeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //Aufruf: http://server:port/Employee/<id>
        //Bsp.    http://localhost:5000/Employee/5
        public IActionResult Details(int id)
        {
            Employee model = _employeeRepository.GetEmployee(id);
            return View(model);
        }
    }
}
