using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class Consola : Articulo
    {
        private bool _esPortatil;
        
        public bool EsPortatil { get {  return _esPortatil; } set {_esPortatil = value; } }
      

        public Consola(): base() { }

        public Consola(string titulo, string autor, int añopublicacion, decimal precio, int stock, string imagen, string sinopsis, bool esPortatil) :base(titulo, autor, añopublicacion, precio, stock, imagen, sinopsis)
        {
            EsPortatil = esPortatil;
            
        }

        public override void PrecioFinal()
        {
            if (_esPortatil)
                Precio -= Precio * (decimal)0.05;
        }
    }
}
