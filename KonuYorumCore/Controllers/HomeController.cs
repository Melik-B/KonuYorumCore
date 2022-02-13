using KonuYorumCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KonuYorumCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //https://localhost:44329/Home/Index Program.cs altındaki route tanımı: controller/ action/id?
        //https://localhost:44329/Home route'da default action tanımı Index
        //https://localhost:44329 route'da default controller tanımı Home, default action tanımı Index
        public IActionResult Index() 
        {
            return View();
        }

        // https://localhost:44329/Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // https://localhost:44329/Home/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}