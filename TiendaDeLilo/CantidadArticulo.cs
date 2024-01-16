using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class CantidadArticulo
    {
        private Articulo _articuloElegido;
        private int _cantidadArtic;

        public int CantidadArtic { get { return _cantidadArtic; } set { _cantidadArtic = value; } }
        public Articulo ArticuloElegido { get { return _articuloElegido; } set { _articuloElegido = value; } }
        public CantidadArticulo() { }

        public CantidadArticulo(Articulo articulo, int cantidadArtic)
        {
            _articuloElegido = articulo;
            _cantidadArtic = cantidadArtic;
        }
    }
}
