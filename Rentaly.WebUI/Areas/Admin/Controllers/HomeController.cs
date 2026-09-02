using Microsoft.AspNetCore.Mvc;

namespace Rentaly.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageTitle = "Dashboard";
            return View();
        }
    }
}