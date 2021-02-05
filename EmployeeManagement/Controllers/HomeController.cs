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
    [Route("Home")]
    public class HomeController : Controller
    {
        //Felder
        private readonly IEmployeeRepository _employeeRepository;

        //Konstruktor
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //Actions
        [Route("/")]
        [RouteAttribute("")]
        [Route("Index")]
        public ViewResult Index()
        {
            //Liste aus Repo holen
            var employees = _employeeRepository.GetAllEmployees();
            
            //An View weiterleiten und zurückliefern
            return View(employees);
        }

        [RouteAttribute("Details/{id?}")] //? kennzeichnet Parameter als optional
        public ViewResult Details(int? id)
        {
            //return "id= " + id.Value.ToString() + " and name "+ name;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //Employee model = _employeeRepository.GetEmployee(id.HasValue ? (int)id : 1);
            Employee model = _employeeRepository.GetEmployee(id ?? 1);
            sw.Stop();

            Debug.WriteLine("Timer Frequenz: " + Stopwatch.Frequency);
            Debug.WriteLine("Tick Time: " + 1.0 / Stopwatch.Frequency);

            //ViewData["PageTitle"] = "Employee Details";
            //ViewData["Employee"] = model;

            ViewBag.Title = "Employee Details"; // ???
            ViewData["TimeSpanTicks"] = sw.ElapsedTicks;
            ViewData["ms"] = sw.ElapsedMilliseconds;

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel();
            homeDetailsViewModel.Employee = model;
            homeDetailsViewModel.Headline = "Employee Data";

            return View(homeDetailsViewModel);
        }

        [RouteAttribute("Create")]
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }

        [Route("Create")]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }


        #region Beispielmethoden für ActionResult
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
        #endregion
    }
}
