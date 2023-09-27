using Microsoft.AspNetCore.Mvc;

namespace ItlaTv_.Controllers
{
    public class SeriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
