using Crud_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Crud_Web_App.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        public ILogger<HomeController> Logger { get; } = logger;

        // ������� Index ����� ������� �� �������� ��������.
        public IActionResult Index()
        {
            return View();
        }

        // ������� Privacy ����� ������� �� ���������� � ���������� �� �������������.
        public IActionResult Privacy()
        {
            return View();
        }

        // ������� Error ����� ������� �� ���������� � ������, ���� ������� ��� ����� �� ��� ErrorViewModel � �������� RequestId.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
