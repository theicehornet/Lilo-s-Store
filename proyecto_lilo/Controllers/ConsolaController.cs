using Microsoft.AspNetCore.Mvc;
using TiendaDeLilo;

namespace proyecto_lilo.Controllers
{
    public class ConsolaController : Controller
    {
        TiendaDeLilo.System sistema = TiendaDeLilo.System.Instancia;
        
        public IActionResult Index()
        {
            List<Consola> consolas = sistema.ObtenerConsolas();
            return View(consolas);
        }

        public IActionResult BusquedaConsola(string id)
        {
            try
            {
                Consola consola = sistema.BuscarConsolaPorId(id);
                return View(consola);
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
