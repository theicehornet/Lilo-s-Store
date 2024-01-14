using System;

namespace TiendaDeLilo
{
    public class System
    {
        #region Singleton 
        private static System _instancia;

        public static System Instancia 
        { 
            get
            {
                if (_instancia == null)
                    _instancia = new System();
                return _instancia; 
            } 
        }

        private List<Usuario> _usuarios;
        private List<Poster> _posters;
        private List<Consola> _consolas;
        private List<Articulo> _articulos;
        private string _emoliente;

        private System() 
        {
            _usuarios = new List<Usuario>();
            _articulos = new List<Articulo>();
            _consolas = new List<Consola>();
            _posters = new List<Poster>();
            _emoliente = "Emoliente de piña";
            Precarga();
        }

        #endregion

        #region Altamethods
        public void AltaUsuario(Usuario user)
        {
            ValidarUsuariosNoRegistrado(user);
            _usuarios.Add(user);
        }

        public void AltaConsola(Consola consola)
        {
            ValidarConsolaNoRegistrada(consola);
            _consolas.Add(consola);
        }

        public void AltaPoster(Poster poster)
        {
            ValidarPosterNoRegistrada(poster);
            _posters.Add(poster);
        }

        public void AltaArticulo(Articulo articulo)
        {
            ValidarArticuloNoRegistrado(articulo);
            _articulos.Add(articulo);
        }

        public void AltaCompra(Compra com)
        {

        }

        #endregion

        #region ObtenerListas
        public List<Usuario> ObtenerUsuarios()
        {
            return [.. _usuarios];
        }
        public List<Articulo> ObtenerArticulos()
        {
            return [.. _articulos];
        }
        public List<Consola> ObtenerConsolas()
        {
            return [.. _consolas];
        }
        public List<Poster> ObtenerPosters()
        {
            return [.. _posters];
        }
        #endregion

        #region EliminarMethods
        public void EliminarUsuario(Usuario usuario)
        {
            bool encontrado = false;
            int i = 0;
            while (i < _usuarios.Count && !encontrado)
            {
                if (usuario.Equals(_usuarios[i]))
                {
                    _usuarios.RemoveAt(i);
                    encontrado = true;
                }
                i++;
            }
            throw new Exception("Hubo un error al eliminar la cuenta");
        }
        public void EliminarUsuario(string correo)
        {
            int i = 0;
            while (i < _usuarios.Count)
            {
                if (correo.Equals(_usuarios[i].Correo))
                {
                    _usuarios.RemoveAt(i);
                    return;
                }
                i++;
            }
            throw new Exception("Hubo un error al eliminar la cuenta");
        }
        public void EliminarArticulo(Articulo art)
        {
            bool encontrado = false;
            int i = 0;
            while (i < _articulos.Count && !encontrado)
            {
                if (art.Equals(_articulos[i]))
                {
                    _articulos.RemoveAt(i);
                }
                i++;
            }
        }
        public void EliminarConsola(Consola consola)
        {
            bool encontrado = false;
            int i = 0;
            while (i < _consolas.Count && !encontrado)
            {
                if (consola.Equals(_consolas[i]))
                {
                    _consolas.RemoveAt(i);
                }
                i++;
            }
        }
        public void EliminarPoster(Poster poster)
        {
            bool encontrado = false;
            int i = 0;
            while (i < _posters.Count && !encontrado)
            {
                if (poster.Equals(_posters[i]))
                {
                    _posters.RemoveAt(i);
                }
                i++;
            }
        }
        #endregion

        #region ValidacionesParaAgregarAlSistema

        private void ValidarArticuloNoRegistrado(Articulo articulo)
        {
            articulo.Validar();
            if (_articulos.Contains(articulo))
                throw new Exception("El articulo ya se encuentra registrado!");
        }

        private void ValidarPosterNoRegistrada(Poster poster)
        {
            poster.Validar();
            if (_posters.Contains(poster))
                throw new Exception("La consola ya se encuentra registrada!");
        }
        private void ValidarConsolaNoRegistrada(Consola consola)
        {
            consola.Validar();
            if (_consolas.Contains(consola))
                throw new Exception("La consola ya se encuentra registrada!");
        }

        private void ValidarUsuariosNoRegistrado(Usuario user)
        {
            user.Validar();
            if (_usuarios.Contains(user))
                throw new Exception("El usuario ya se encuentra registrado!");
        }
        #endregion

        #region ActualizarStockMethods
        public void ActualizarStockArticulo(string idArticulo, int cantComprado)
        {
            int i = 0;
            bool encontrado = false;
            while (!encontrado)
            {
                if (_articulos[i].Id.Equals(idArticulo))
                {
                    _articulos[i].Stock -= cantComprado;
                    return;
                }
                i++;
            }
            throw new Exception("No se ha encontrado el articulo");

        }
        public void ActualizarStockPoster(string IdPoster, int cantComprado)
        {
            int i = 0;
            bool encontrado = false;
            while (!encontrado)
            {
                if (_posters[i].Id.Equals(IdPoster))
                {
                    _posters[i].Stock -= cantComprado;
                    return;
                }
                i++;
            }
            throw new Exception("No se ha encontrado el poster");
        }
        public void ActualizarStockConsola(string IdConsola, int cantComprado)
        {
            int i = 0;
            bool encontrado = false;
            while (!encontrado)
            {
                if (_consolas[i].Id.Equals(IdConsola))
                {
                    _consolas[i].Stock -= cantComprado;
                    return;
                }
                i++;
            }
            throw new Exception("No se ha encontrado la consola");
        }
        #endregion

        #region HallarMethods
        public Usuario BuscarUsuarioPorId(string id)
        {
            int i = 0;
            while (i < _usuarios.Count)
            {
                if (_usuarios[i].Id == id)
                    return _usuarios[i];
                i++;
            }
            throw new Exception($"Usuario no encontrado! el id de busqueda es: {id}");
        }
        public Usuario BuscarUsuarioPorCorreo(string correo)
        {
            int i = 0;
            while (i < _usuarios.Count)
            {
                if (_usuarios[i].Correo == correo)
                    return _usuarios[i];
                i++;
            }
            throw new Exception($"Usuario no encontrado! el correo buscado es: {correo}");
        }
        public Articulo BuscarArticuloPorId(string id)
        {
            int i = 0;
            while (i < _articulos.Count)
            {
                if (_articulos[i].Id == id)
                    return _articulos[i];
                i++;
            }
            throw new Exception($"Articulo no encontrado! el id de busqueda es: {id}");
        }
        public Poster BuscarPosterPorId(string id)
        {
            int i = 0;
            while ( i < _posters.Count)
            {
                if (_posters[i].Id == id)
                    return _posters[i];
                i++;
            }
            throw new Exception($"Poster no encontrado! el id de busqueda es: {id}");
        }
        public Consola BuscarConsolaPorId(string id)
        {
            int i = 0;
            while (i < _consolas.Count)
            {
                if (_consolas[i].Id == id)
                    return _consolas[i];
                i++;
            }
            throw new Exception($"Consola no encontrado! el id de busqueda es: {id}");
        }
        #endregion
        
        public void ValidarSesion(string correo, string passw)
        {
            Usuario user = BuscarUsuarioPorCorreo(correo);
            if(user.Contraseña.Equals(passw))
            {
                throw new Exception("La contraseña no es correcta");
            }
        }

        #region Precarga

        private void Precarga()
        {
            UsuariosPrecargados();
            PostersPrecargados();
            ArticulosPrecargados();
            ConsolaSPrecargados();
        }

        private void UsuariosPrecargados()
        {
            AltaUsuario(new Miembro("Katrina","Gonzles",new DateTime(2003,06,03),"123456789","katrina123@gmail.com","miau123"));
            AltaUsuario(new Administrador("789456123","losapus123@gmail.com","123456","Papu"));
        }
        private void ArticulosPrecargados()
        {
            AltaArticulo(new Manga("One Piece","Oda",1999,450m,true,30, "https://cdnx.jumpseller.com/japan-market-chile/image/37284507/61mniMpibCL.jpg?1688672598", "One Piece narra la historia de un joven llamado Monkey D. Luffy, que inspirado por su amigo pirata Shanks, comienza un viaje para alcanzar su sueño, ser el Rey de los piratas, para lo cual deberá encontrar el tesoro One Piece dejado por el anterior rey de los piratas Gol D. Roger."));
            AltaArticulo(new Manga("Oshi no ko", "Aka Akasaka", 2020, 500m, true, 100, "https://ramenparados.com/wp-content/uploads/2022/01/Oshi-no-Ko-1-esp-729x1024.jpg", "Gorō es un médico que lleva el parto de su idol favorita, Ai Hoshino, que ha tomado un parón en su carrera de idol para tener a sus gemelas. Antes de que Ai de a luz, Gorō muere en un accidente, y es reencarnado en una de las gemelas de Ai, Aquamarine Hoshino, pero con sus recuerdos intactos."));
            AltaArticulo(new Manga("Jujutsu Kaisen", "Gege Akutami",2018,400m,true,350, "https://m.media-amazon.com/images/I/81wkV954uQL._AC_UF1000,1000_QL80_.jpg", "Jujutsu Kaisen es un anime que sigue la historia de Yuji Itadori, un estudiante de secundaria que vive en Sendai junto a su abuelo. Aunque tenga un talento innato para el deporte, evita de todas formas el equipo de pista debido a su aversión al atletismo."));
            foreach(Articulo art in _articulos)
            {
                art.Generos.Add(Genero.SCIFI);
                art.Generos.Add(Genero.ROMANCE);
                art.Generos.Add(Genero.RPG);
            }
        }
        private void PostersPrecargados()
        {
            AltaPoster(new Poster("Wanted Luffy", "https://http2.mlstatic.com/D_NQ_NP_950040-MLU71567421573_092023-O.webp", 100m,30));
            AltaPoster(new Poster("Wanted Trafalgar", "https://otakucollectives.com/cdn/shop/files/TrafalgarLawwantedposter.jpg?v=1690947333", 100m,30));
            AltaPoster(new Poster("Ai Poster", "https://akibamarket.com/wp-content/uploads/2023/05/OSHI-NO-KO.jpg", 250m,50));
            AltaPoster(new Poster("Jujutsu Kaisen", "https://i.ebayimg.com/images/g/igYAAOSwuvBhHCUR/s-l1600.jpg", 250m,80));
        }
        private void ConsolaSPrecargados()
        {
        
        }
        #endregion

    }
}
