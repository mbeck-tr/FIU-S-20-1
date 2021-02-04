using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("[controller]/[action]")]
    public class DepartmentController : Controller
    {
        [Route("")]
        //[Route("[action]")]
        //{controller=Department}/{action=List}
        public string List()
        {
            return "List of DepartmentController";
        }

        //[Route("[action]")]
        //{controller=Department}/{action=Details}
        public string Details()
        {
            return "Details of DepartmentController";
        }
    }
}
