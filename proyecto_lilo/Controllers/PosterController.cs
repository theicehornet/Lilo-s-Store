using Microsoft.AspNetCore.Mvc;
using TiendaDeLilo;

namespace proyecto_lilo.Controllers
{
    public class PosterController : Controller
    {
        TiendaDeLilo.System sistema = TiendaDeLilo.System.Instancia;
        public IActionResult Index()
        {
            List<Poster> posters = sistema.ObtenerPosters();
            return View(posters);
        }

        public IActionResult BuscarPoster(string id)
        {
            Poster poster = sistema.BuscarPosterPorId(id);
            return View(poster);
        }
    }
}
