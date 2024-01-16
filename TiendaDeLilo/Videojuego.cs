using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class Videojuego : Articulo
    {
        private bool _isNacional;
        private List<Genero> _generos;
        private List<Poster> _posters;

        public bool IsNacional { get { return _isNacional; } set { _isNacional = value; } }
        public List<Genero> Generos { get { return _generos; } set { _generos = value; } }
        public List<Poster> Posters { get { return _posters; } set { _posters = value; } }

        public Videojuego(): base() { 
            PrecioFinal();
            _generos = new List<Genero>();
            _posters = new List<Poster>();
            _isNacional = false;
        }

        public bool IsPosterInArticulo(Poster p)
        {
            return _posters.Contains(p);
        }

        public Videojuego(string titulo, string autor, int añopublicacion, decimal precio,bool isnacional, int stock, string imagen, string sinopsis) :base(titulo,autor,añopublicacion,precio,stock, imagen, sinopsis)
        {
            _generos = new List<Genero>();
            _posters = new List<Poster>();
            _isNacional = isnacional;
            PrecioFinal();
        }

        public override void PrecioFinal()
        {
            if (_isNacional)
            {
                Precio -= Precio * (decimal)0.2;
            }
        } 
    }
}
