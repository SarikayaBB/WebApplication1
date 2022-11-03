using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        #region db
        public readonly NorthwindContext _db;
        public CategoryController(NorthwindContext db)
        {
            _db = db;
        }
        #endregion
        public IActionResult Index()
        {
            return View(_db.Categories.ToList());
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid) // gonderilen input database kurallarina uyuyor mu (nvarchar(15) gibi)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
            }

            TempData["success"] = "Basariyla eklendi.";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int CategoryId)
        {
            var cat = _db.Categories.Find(CategoryId);
            return View(cat);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Update(category);
                _db.SaveChanges();
            }
            TempData["success"] = "Basariyla guncellendi.";
            return RedirectToAction("Index");
        }


       
        public IActionResult Delete(int CategoryId)
        {
            Category cat = _db.Categories.Find(CategoryId);
            _db.Remove(cat);
            _db.SaveChanges();

            TempData["success"] = "Basariyla silindi.";

            return RedirectToAction("Index");
        }
    }
}
