using Microsoft.AspNetCore.Mvc;
using proyecto_lilo.Recursos;
using TiendaDeLilo;

namespace proyecto_lilo.Controllers
{
    public class UsuarioController : Controller
    {
        TiendaDeLilo.System sistema = TiendaDeLilo.System.Instancia;
        public IActionResult Registro()
        {
            ViewData["Title"] = "Registro";
            return View();
        }
        [HttpPost]
        public IActionResult Registro(Miembro user)
        {
            try
            {
                user.Contraseña = Utilidades.EncriptarContra(user.Contraseña);
                sistema.AltaUsuario(user);
                return RedirectToAction("IniciarSesion");
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                ViewData["Title"] = "Registro";
            }
            return View(user);
        }

        public IActionResult IniciarSesion()
        {
            ViewData["Title"] = "Iniciar Sesión";
            return View();
        }
        [HttpPost]
        public IActionResult IniciarSesion(string correo, string passw)
        {
            try
            {
                passw = Utilidades.EncriptarContra(passw);
                sistema.ValidarSesion(correo, passw);
                HttpContext.Session.SetString("Correo",correo);
                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                ViewData["Title"] = "Iniciar Sesión";
            }
            return View();
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            ViewData["Title"] = "Cerrar Sesión";
            return RedirectToAction("IniciarSesion"); ;
        }
        
        public IActionResult EliminarCuenta()
        {
            //if (HttpContext.Session.GetString("correo") == null)
            //    return RedirectToAction("IniciarSesion");
            ViewData["Title"] = "Eliminar Cuenta";
            return View();
        }
        [HttpPost]
        public IActionResult EliminarCuenta(bool confirmacion, string passw)
        {
            //if (HttpContext.Session.GetString("correo") == null)
            //    return RedirectToAction("IniciarSesion");
            try
            {
                if (confirmacion)
                {
                    passw = Utilidades.EncriptarContra(passw);
                    Usuario user = sistema.BuscarUsuarioPorCorreo(HttpContext.Session.GetString("correo"));
                    if(user.Contraseña.Equals(passw))
                        sistema.EliminarUsuario(user);
                    return RedirectToAction("Index", "Home");
                }
            }catch (Exception ex)
            { 
                ViewData["Error"] = ex.Message;
                ViewData["Title"] = "Eliminar Cuenta";
                return View();
            }
            return RedirectToAction("EliminarCuenta");
        }
    }
}
