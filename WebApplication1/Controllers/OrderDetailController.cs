using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrderDetailController : Controller
    {
        #region db
        private readonly NorthwindContext _db;
        public OrderDetailController(NorthwindContext db)
        {
            _db = db;
        }
        #endregion

        public IActionResult Index()
        {
            return View(_db.OrderDetailsExtendeds.ToList());
        }
        public IActionResult GetAllJson()
        {
            List<OrderDetailsExtended> list = _db.OrderDetailsExtendeds.ToList<OrderDetailsExtended>();

            return Json(new { data = list });
        }
    }
}
