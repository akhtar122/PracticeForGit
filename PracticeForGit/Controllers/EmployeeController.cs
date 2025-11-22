using Microsoft.AspNetCore.Mvc;

namespace PracticeForGit.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
