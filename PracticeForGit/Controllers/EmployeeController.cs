using Microsoft.AspNetCore.Mvc;
using PracticeForGit.Models;
using System.Linq;

namespace PracticeForGit.Controllers
{
    public class EmployeeController : Controller
    {
        // make the list static so added employees persist for the lifetime of the app process
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Position = "Developer", Salary = 15200 },
            new Employee { Id = 2, Name = "Bob", Position = "Designer" ,Salary = 15200},
            new Employee { Id = 3, Name = "Charlie", Position = "Manager", Salary = 15200 }
        };

        public IActionResult Index()
        {
            var emplist = employees;
            return View(emplist);
        }

        public IActionResult Details(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return View(emp);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee(Employee model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var nextId = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            model.Id = nextId;
            employees.Add(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
