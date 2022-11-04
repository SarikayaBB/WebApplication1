using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly NorthwindContext _db;
        public EmployeeController(NorthwindContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Employees.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Add(employee);
                _db.SaveChanges();
                TempData["success"] = "Basariyla eklendi.";

            }
            return RedirectToAction("Index");
        }
    }
}
