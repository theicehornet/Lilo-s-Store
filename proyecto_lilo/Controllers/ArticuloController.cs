using Microsoft.AspNetCore.Mvc;
using TiendaDeLilo;

namespace proyecto_lilo.Controllers
{
    public class ArticuloController : Controller
    {
        TiendaDeLilo.System sistema = TiendaDeLilo.System.Instancia;
        public IActionResult Mangas()
        {
            ViewData["Title"] = "Mangas";
            List<Manga> mangas = sistema.ObtenerMangas();
            return View(mangas);
        }
        public IActionResult Consolas()
        {
            ViewData["Title"] = "Consolas";
            List<Consola> consolas = sistema.ObtenerConsolas();
            return View(consolas);
        }
        public IActionResult Videojuegos()
        {
            ViewData["Title"] = "Videojuegos";
            List<Videojuego> videojuegos = sistema.ObtenerVideojuegos();
            return View(videojuegos);
        }
        public IActionResult Posters()
        {
            ViewData["Title"] = "Posters";
            List<Poster> posters = sistema.ObtenerPosters();
            return View(posters);
        }

        
        public IActionResult Manga(string id)
        {
            try
            {
                Manga articulo = sistema.BuscarMangaPorId(id);
                ViewData["Title"] = articulo.Titulo;
                return View(articulo);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Mangas"); 
            }
        }
        public IActionResult Consola(string id)
        {
            try
            {
                Consola articulo = sistema.BuscarConsolaPorId(id);
                ViewData["Title"] = articulo.Titulo;
                return View(articulo);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Consola");
            }
        }
        public IActionResult Videojuego(string id)
        {
            try
            {
                Videojuego articulo = sistema.BuscarVidejuegoPorId(id);
                ViewData["Title"] = articulo.Titulo;
                return View(articulo);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Videojuegos");
            }
        }
        public IActionResult Poster(string id)
        {
            try
            {
                Poster articulo = sistema.BuscarPosterPorId(id);
                ViewData["Title"] = articulo.Titulo;
                return View(articulo);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Posters");
            }
        }



        [HttpPost]
        public IActionResult AgregarArticulo(int cantidad, string correo, string id_art)
        {
            try
            {
                sistema.AltaCarro(sistema.BuscarUsuarioPorCorreo(correo), id_art, cantidad);
                TempData["Exito"] = "Se agrego al carrito de compra";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return Redirect($"/Articulo/BuscarArticulo/{id_art}");
        }
    }
}
