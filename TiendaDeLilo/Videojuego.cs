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

        public bool IsNacional { get { return _isNacional; } set { _isNacional = value; } }

        public Videojuego(): base() { PrecioFinal(); }

        public Videojuego(string titulo, string autor, int añopublicacion, decimal precio,bool isnacional, int stock, string imagen, string sinopsis) :base(titulo,autor,añopublicacion,precio,stock, imagen, sinopsis)
        {
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
