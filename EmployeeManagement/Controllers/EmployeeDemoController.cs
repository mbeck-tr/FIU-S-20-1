using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagement.Controllers
{
    public class EmployeeDemoController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IEmployeeRepositoryDemo _employeeRepository;

        public EmployeeDemoController(IEmployeeRepositoryDemo employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //Aufruf: http://server:port/Employee/<id>
        //Bsp.    http://localhost:5000/Employee/5
        public IActionResult Details(int id)
        {
            EmployeeDemo model = _employeeRepository.GetEmployee(id);
            return View(model);
        }
    }
}
