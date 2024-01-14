using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public abstract class Articulo
    {
        //atributos

        #region Atributos
        private readonly string _id;
        private string _titulo;
        private string _autor;
        private string _imagen;
        private List<Genero> _generos;
        private List<Poster> _posters;
        private int _añopublicacion;
        private decimal _precio;
        private string _sinopsis;
        private int _stock;

        #endregion

        #region Propiedades
        public string Id { get { return _id; } }
        public string Imagen { get { return _imagen; } set { _imagen = value; } }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string Autor { get { return _autor; } set { _autor = value; } }
        public List<Genero> Generos { get { return _generos; } set { _generos = value; } }
        public List<Poster> Posters { get { return _posters; } set { _posters = value; } } 
        public int AñoPublicacion { get { return _añopublicacion; } set { _añopublicacion = value; } }
        public decimal Precio {  get { return _precio; } set { _precio = value; } }
        public string Sinopsis { get { return _sinopsis; } set { _sinopsis = value; } }
        public int Stock { get { return _stock; } set { _stock = value; } }
        #endregion

        #region Constructores
        public Articulo() 
        { 
            _id = Guid.NewGuid().ToString();
        }

        public Articulo(string titulo,string autor, int añopublicacion, decimal precio, int stock, string imagen, string sinopsis)
        {
            _id = Guid.NewGuid().ToString();
            _generos = new List<Genero>();
            _posters = new List<Poster>();
            _titulo = titulo;
            _autor = autor;
            _precio = precio;
            _añopublicacion = añopublicacion;
            _stock = stock;
            Imagen = imagen;
            _sinopsis = sinopsis;
        }
        #endregion

        #region Validaciones
        public void Validar()
        {
            ValidarTitulo();
            ValidarAutor();
            ValidarAño();
        }

        private void ValidarAño()
        {
            if (_añopublicacion > DateTime.Now.Year)
                throw new Exception("El año de publicacion no puede ser mayor al actual!");
            if (_añopublicacion < 1980)
                throw new Exception("No existen Articulos existentes antes de 1980!");
        }

        private void ValidarAutor()
        {
            if (string.IsNullOrEmpty(_autor))
                throw new Exception("El autor no puede ser vacío!");

        }

        private void ValidarTitulo()
        {
            if (string.IsNullOrEmpty(_titulo))
                throw new Exception("El titulo no puede ser vacío!");
        }
        #endregion

        public abstract void PrecioFinal();

        public bool IsPosterInArticulo(Poster p)
        {
            return _posters.Contains(p);
        }

        public override bool Equals(object? obj)
        {
            return obj is Articulo art && art.Titulo.Equals(Titulo) && art.Autor.Equals(Autor);
        }

    }
}
