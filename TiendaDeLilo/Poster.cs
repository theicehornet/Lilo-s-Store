using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TiendaDeLilo
{
    public class Poster : Articulo
    {
        private bool _esRelevante = true;

        public bool EsRelevante { get { return _esRelevante; } set { _esRelevante = value; } }

        public Poster(): base() { }

        public Poster(string titulo, string autor, int añoPublicacion, decimal precio, int stock, string imagen, string sinopsis, bool esRelevante) : base(titulo, autor, añoPublicacion, precio, stock, imagen, sinopsis)
        {
            _esRelevante = esRelevante;
        }
        public override bool Equals(object? obj)
        {
            return obj is Poster other && other.Titulo.Equals(Titulo) && other.Imagen.Equals(Imagen);
        }

        public override void PrecioFinal()
        {
            if (_esRelevante)
                Precio += Precio * (decimal)0.1;
        }
    }
}
