using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
