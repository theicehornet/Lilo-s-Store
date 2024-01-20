using Microsoft.AspNetCore.Mvc;
using TiendaDeLilo;

namespace proyecto_lilo.Controllers
{
    public class CarroController : Controller
    {
        TiendaDeLilo.System sistema = TiendaDeLilo.System.Instancia;

        [HttpPost]
        public IActionResult AgregarAlCarro(int cantidad,string? correo,string id_art)
        {
            //Usuario? user;
            //if (correo == null)
            //    user = null;
            //else 
            //    user = sistema.BuscarUsuarioPorCorreo(correo);
            //Carro car = sistema.AltaCarro(user, id_art, cantidad);
            //
            return View();
        }
    }
}
