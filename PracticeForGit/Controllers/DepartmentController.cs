using Microsoft.AspNetCore.Mvc;
using PracticeForGit.Models;
using System.Linq;

namespace PracticeForGit.Controllers
{
    public class DepartmentController : Controller
    {
        // static so changes persist while the app process runs
        private static List<Department> departments = new List<Department>
        {
            new Department { Id = 1, DeprtName = "HR", Description = "Human Resources" },
            new Department { Id = 2, DeprtName = "IT", Description = "Information Technology" },
            new Department { Id = 3, DeprtName = "Finance", Description = "Finance and Accounting" }
        };

        public IActionResult Index()
        {
            return View(departments);
        }

        public IActionResult Details(int id)
        {
            var dept = departments.FirstOrDefault(d => d.Id == id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department model)
        {
            if (!ModelState.IsValid) return View(model);

            var nextId = departments.Any() ? departments.Max(d => d.Id) + 1 : 1;
            model.Id = nextId;
            departments.Add(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dept = departments.FirstOrDefault(d => d.Id == id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department model)
        {
            if (!ModelState.IsValid) return View(model);

            var existing = departments.FirstOrDefault(d => d.Id == model.Id);
            if (existing == null) return NotFound();

            existing.DeprtName = model.DeprtName;
            existing.Description = model.Description;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dept = departments.FirstOrDefault(d => d.Id == id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var dept = departments.FirstOrDefault(d => d.Id == id);
            if (dept != null)
            {
                departments.Remove(dept);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
