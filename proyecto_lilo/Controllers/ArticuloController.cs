using Microsoft.AspNetCore.Mvc;
using TiendaDeLilo;

namespace proyecto_lilo.Controllers
{
    public class ArticuloController : Controller
    {
        TiendaDeLilo.System sistema = TiendaDeLilo.System.Instancia;
        public IActionResult Index()
        {
            ViewData["Title"] = "Mangas y Videojuegos";
            List<Articulo> articulos = sistema.ObtenerArticulos();
            return View(articulos);
        }

        public IActionResult BuscarArticulo(string id)
        {
            Articulo articulo = sistema.BuscarArticuloPorId(id);
            return View(articulo);
        }

        public IActionResult ComprarArticulo(int cantidad, string correo, string id_art)
        {
            try
            {
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Redirect($"/Articulo/BuscarArticulo/{id_art}");
            }
            return View();
        }


    }
}
