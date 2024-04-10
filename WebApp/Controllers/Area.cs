using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AreaController : Controller
    {
        public IActionResult Area()
        {
            return View();
        }
    }
}
