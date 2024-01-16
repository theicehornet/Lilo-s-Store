using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class Manga: Articulo
    {
        private bool _isImportado;
        private List<Genero> _generos;
        private List<Poster> _posters;

        public bool IsImportado { get { return _isImportado;} set { _isImportado = value; } }
        public List<Genero> Generos { get { return _generos; } set { _generos = value; } }
        public List<Poster> Posters { get { return _posters; } set { _posters = value; } }

        public Manga() : base() {
            _generos = new List<Genero>();
            _posters = new List<Poster>();
            _isImportado = false;
            PrecioFinal();
        }

        public bool IsPosterInArticulo(Poster p)
        {
            return _posters.Contains(p);
        }

        public Manga(string titulo, string autor, int añopublicacion, decimal precio, bool isimportado,int stock,string imagen ,string sinopsis) : base(titulo, autor, añopublicacion, precio, stock, imagen, sinopsis)
        {
            _generos = new List<Genero>();
            _posters = new List<Poster>();
            _isImportado = isimportado;
            PrecioFinal();
        }

        public override void PrecioFinal()
        {
            if (_isImportado)
            {
                Precio += Precio * (decimal)0.5;
            }
        }
    }
}
