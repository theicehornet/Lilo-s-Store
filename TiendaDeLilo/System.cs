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
        private List<Articulo> _articulos;
        private List<Compra> _compras;
        private List<Carro> _carros;
        private string _emoliente;

        private System() 
        {
            _usuarios = new List<Usuario>();
            _articulos = new List<Articulo>();
            _compras = new List<Compra>();
            _carros = new List<Carro>();
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

        public void AltaArticulo(Articulo articulo)
        {
            ValidarArticuloNoRegistrado(articulo);
            _articulos.Add(articulo);
        }

        public Carro AltaCarro(Usuario autor,string idArticulo,int cantArticulo)
        {
            Carro carro = new Carro(autor);
            Articulo articulo = BuscarArticuloPorId(idArticulo);
            carro.AgregarArticulo(articulo,cantArticulo);
            _carros.Add(carro);
            return carro;
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
        public List<Articulo> ObtenerVideojuegos()
        {
            List<Articulo> dev = new List<Articulo>();
            foreach (Articulo art in _articulos)
            {
                if (art is Videojuego con)
                    dev.Add(con);
            }
            return dev;
        }
        public List<Articulo> ObtenerMangas()
        {
            List<Articulo> dev = new List<Articulo>();
            foreach (Articulo art in _articulos)
            {
                if (art is Manga con)
                    dev.Add(con);
            }
            return dev;
        }
        public List<Articulo> ObtenerConsolas()
        {
            List<Articulo> dev = new List<Articulo>();
            foreach(Articulo art in _articulos)
            {
                if (art is Consola con)
                    dev.Add(con);
            }
            return dev;
        }
        public List<Articulo> ObtenerPosters()
        {
            List<Articulo> dev = new List<Articulo>();
            foreach (Articulo art in _articulos)
            {
                if (art is Poster pos)
                    dev.Add(pos);
            }
            return dev;
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
                    //TODO: mapear para crear una nueva lista
                    _articulos.RemoveAt(i);
                    encontrado = true;
                }
                i++;
            }
            if(!encontrado)
                throw new Exception($"No se encontro al articulo con id {art.Id}");
        }
        #endregion

        #region ValidacionesParaAgregarAlSistema

        private void ValidarArticuloNoRegistrado(Articulo articulo)
        {
            articulo.Validar();
            if (_articulos.Contains(articulo))
                throw new Exception("El articulo ya se encuentra registrado!");
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
            while (!encontrado && i < _articulos.Count)
            {
                if (_articulos[i].Id.Equals(idArticulo))
                {
                    _articulos[i].Stock -= cantComprado;
                    encontrado = true;
                }
                i++;
            }
            if(encontrado == false)
                throw new Exception($"No se ha encontrado el articulo con id {idArticulo}");
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

        public Articulo BuscarMangaPorId(string id)
        {
            Articulo art = BuscarArticuloPorId(id);
            if (art is not Manga)
                throw new Exception("El id buscado no corresponde a un manga");
            return art;
        }
        public Articulo BuscarVidejuegoPorId(string id)
        {
            Articulo art = BuscarArticuloPorId(id);
            if (art is not Videojuego)
                throw new Exception("El id buscado no corresponde a un videojuego");
            return art;
        }
        public Articulo BuscarPosterPorId(string id)
        {
            Articulo art = BuscarArticuloPorId(id);
            if (art is not Poster)
                throw new Exception("El id buscado no corresponde a un poster");
            return art;
        }
        public Articulo BuscarConsolaPorId(string id)
        {
            Articulo art = BuscarArticuloPorId(id);
            if (art is not Consola)
                throw new Exception("El id buscado no corresponde a un consola");
            return art;
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
            ArticulosPrecargados();
        }

        private void UsuariosPrecargados()
        {
            AltaUsuario(new Miembro("Katrina","Gonzles",new DateTime(2003,06,03),"123456789","katrina123@gmail.com","miau123"));
            AltaUsuario(new Administrador("789456123","losapus123@gmail.com","123456","Papu"));
        }
        private void ArticulosPrecargados()
        {
            Manga m1 = new Manga("One Piece", "Oda", 1999, 450m, true, 30, "https://cdnx.jumpseller.com/japan-market-chile/image/37284507/61mniMpibCL.jpg?1688672598", "One Piece narra la historia de un joven llamado Monkey D. Luffy, que inspirado por su amigo pirata Shanks, comienza un viaje para alcanzar su sueño, ser el Rey de los piratas, para lo cual deberá encontrar el tesoro One Piece dejado por el anterior rey de los piratas Gol D. Roger.");
            Manga m2 = new Manga("Oshi no ko", "Aka Akasaka", 2020, 500m, true, 100, "https://ramenparados.com/wp-content/uploads/2022/01/Oshi-no-Ko-1-esp-729x1024.jpg", "Gorō es un médico que lleva el parto de su idol favorita, Ai Hoshino, que ha tomado un parón en su carrera de idol para tener a sus gemelas. Antes de que Ai de a luz, Gorō muere en un accidente, y es reencarnado en una de las gemelas de Ai, Aquamarine Hoshino, pero con sus recuerdos intactos.");
            Manga m3 = new Manga("Jujutsu Kaisen", "Gege Akutami", 2018, 400m, true, 350, "https://m.media-amazon.com/images/I/81wkV954uQL._AC_UF1000,1000_QL80_.jpg", "Jujutsu Kaisen es un anime que sigue la historia de Yuji Itadori, un estudiante de secundaria que vive en Sendai junto a su abuelo. Aunque tenga un talento innato para el deporte, evita de todas formas el equipo de pista debido a su aversión al atletismo.");
            m1.Generos.Add(Genero.ACCION);
            m1.Generos.Add(Genero.AVENTURA);
            m1.Generos.Add(Genero.ROMANCE);
            m2.Generos.Add(Genero.DRAMA);
            m2.Generos.Add(Genero.AVENTURA);
            m2.Generos.Add(Genero.ROMANCE);
            m3.Generos.Add(Genero.DRAMA);
            m3.Generos.Add(Genero.AVENTURA);
            m3.Generos.Add(Genero.SCIFI);
            AltaArticulo(m1);
            AltaArticulo(m2);
            AltaArticulo(m3);
            AltaArticulo(new Poster("Wanted Luffy Poster", "Oda", 1999, 210m, 30, "https://http2.mlstatic.com/D_NQ_NP_950040-MLU71567421573_092023-O.webp","Poster de luffy",true));
            AltaArticulo(new Poster("Wanted Trafalgar Poster","Oda", 1999, 210m, 30, "https://otakucollectives.com/cdn/shop/files/TrafalgarLawwantedposter.jpg?v=1690947333","Poster de trafalgar",true));
            AltaArticulo(new Poster("Ai Poster", "Aka Akasaka", 2020, 250m, 50, "https://akibamarket.com/wp-content/uploads/2023/05/OSHI-NO-KO.jpg","Poster de Ai", true));
            AltaArticulo(new Poster("Jujutsu Kaisen Poster", "Gege Akutami", 2018, 250m, 80, "https://i.ebayimg.com/images/g/igYAAOSwuvBhHCUR/s-l1600.jpg","Poster de la serie Jujutsu Kaisen", true));
        }
        #endregion

    }
}
