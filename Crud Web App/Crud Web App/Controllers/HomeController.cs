using Crud_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Crud_Web_App.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        public ILogger<HomeController> Logger { get; } = logger;

        // Методът Index връща изгледа за главната страница.
        public IActionResult Index()
        {
            return View();
        }

        // Методът Privacy връща изгледа за страницата с политиката за поверителност.
        public IActionResult Privacy()
        {
            return View();
        }

        // Методът Error връща изгледа за страницата с грешки, като създава нов обект от тип ErrorViewModel с текущото RequestId.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
