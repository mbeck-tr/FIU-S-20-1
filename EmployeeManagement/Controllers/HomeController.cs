using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string Index()
        {
            return _employeeRepository.GetEmployee(2).Name;
        }

        public string test()
        {
            return "Test";
        }

        public string DetailsString()
        {
            Employee model = _employeeRepository.GetEmployee(3);
            return $"Id: {model.Id} Name: {model.Name} Dep: {model.Department}";
        }

        public ObjectResult DetailsObject()
        {
            Employee model = _employeeRepository.GetEmployee(2);
            return new ObjectResult(model);
        }

        public JsonResult DetailsJson()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return new JsonResult(model);
        }

        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            
            ViewData["PageTitle"] = "Employee Details";
            //ViewData["Employee"] = model;

            return View(model);
        }
    }
}
