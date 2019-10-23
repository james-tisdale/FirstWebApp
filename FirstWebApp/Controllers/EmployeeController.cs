using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstWebApp.Models;

namespace FirstWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            EmployeeRepository repo = new EmployeeRepository();
            List<Employee> employees = repo.GetAllEmployees();

            return View(employees);
        }
    }
}