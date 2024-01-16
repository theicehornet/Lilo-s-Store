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

        
        public IActionResult BuscarManga(string id)
        {
            try
            {
                Manga articulo = sistema.BuscarMangaPorId(id);
                ViewData["Title"] = articulo.Titulo;
                return View(articulo);
            }
            catch (Exception ex)
            {
                return Ok(); 
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
