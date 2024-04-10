using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
