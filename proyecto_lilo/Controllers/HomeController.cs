using Microsoft.AspNetCore.Mvc;
using proyecto_lilo.Models;
using System.Diagnostics;
using TiendaDeLilo;

namespace proyecto_lilo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        TiendaDeLilo.System sistema = TiendaDeLilo.System.Instancia;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Bienvenido";
            return View();
        }
    }
}
