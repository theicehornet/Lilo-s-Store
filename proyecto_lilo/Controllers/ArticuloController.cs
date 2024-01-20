using Microsoft.AspNetCore.Mvc;
using System;
using TiendaDeLilo;

namespace proyecto_lilo.Controllers
{
    public class ArticuloController : Controller
    {
        TiendaDeLilo.System sistema = TiendaDeLilo.System.Instancia;

        public IActionResult Index(string id)
        {
            Articulo art = sistema.BuscarArticuloPorId(id);
            if(art is Poster)
                return Redirect($"/Articulo/Poster/{id}");
            else if (art is Manga)
                return Redirect($"/Articulo/Manga/{id}");
            else if (art is Videojuego)
                return Redirect($"/Articulo/Videojuego/{id}");
            else
                return Redirect($"/Articulo/Consola/{id}");
        }

        public IActionResult Mangas()
        {
            ViewData["Title"] = "Mangas";
            List<Articulo> mangas = sistema.ObtenerMangas();
            return View("Articulos",mangas);
        }
        public IActionResult Consolas()
        {
            ViewData["Title"] = "Consolas";
            List<Articulo> consolas = sistema.ObtenerConsolas();
            return View("Articulos",consolas);
        }
        public IActionResult Videojuegos()
        {
            ViewData["Title"] = "Videojuegos";
            List<Articulo> videojuegos = sistema.ObtenerVideojuegos();
            return View("Articulos",videojuegos);
        }
        public IActionResult Posters()
        {
            ViewData["Title"] = "Posters";
            List<Articulo> posters = sistema.ObtenerPosters();
            return View("Articulos",posters);
        }

        
        public IActionResult Manga(string id)
        {
            try
            {
                Articulo articulo = sistema.BuscarMangaPorId(id);
                ViewData["Title"] = articulo.Titulo;
                return View("Articulo",articulo);
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
                Articulo articulo = sistema.BuscarConsolaPorId(id);
                ViewData["Title"] = articulo.Titulo;
                return View("Articulo",articulo);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Consolas");
            }
        }
        public IActionResult Videojuego(string id)
        {
            try
            {
                Articulo articulo = sistema.BuscarVidejuegoPorId(id);
                ViewData["Title"] = articulo.Titulo;
                return View("Articulo", articulo);
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
                Articulo articulo = sistema.BuscarPosterPorId(id);
                ViewData["Title"] = articulo.Titulo;
                return View("Articulo",articulo);
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
