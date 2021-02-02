using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Employee model = _employeeRepository.GetEmployee(1);
            sw.Stop();

            Debug.WriteLine("Timer Frequenz: " + Stopwatch.Frequency);
            Debug.WriteLine("Tick Time: " + 1.0 / Stopwatch.Frequency);
            
            //ViewData["PageTitle"] = "Employee Details";
            //ViewData["Employee"] = model;

            ViewBag.PageTitle = "Employee Details";
            ViewData["TimeSpanTicks"] = sw.ElapsedTicks;
            ViewData["ms"] = sw.ElapsedMilliseconds;

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel();
            homeDetailsViewModel.Employee = model;
            homeDetailsViewModel.Headline = "Employee Data";

            return View(homeDetailsViewModel);
        }
    }
}
