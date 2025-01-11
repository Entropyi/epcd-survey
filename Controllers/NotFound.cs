using Microsoft.AspNetCore.Mvc;

namespace feedback.Controllers
{
    public class NotFound : Controller
    {
        // GET: NotFound
        public ActionResult Index()
        {
            return View();
        }
    }
}