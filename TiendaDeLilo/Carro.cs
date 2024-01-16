using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class Carro
    {
        private readonly string _id;
        private List<CantidadArticulo> _articulos;
        private List<Consola> _consolas;
        private Usuario _interesado;
        private List<Poster> _posters;

        public string Id { get { return _id; }  }
        public Usuario Interesado { get { return _interesado; } set { _interesado = value; } }
        public List<CantidadArticulo> Articulos { get { return _articulos; } set { _articulos = value; } }
        public List<Consola> Consolas { get { return _consolas; } set { _consolas = value; } }
        public List<Poster> Posters { get { return _posters; } set { _posters = value; } }

        public Carro() { _id = Guid.NewGuid().ToString(); }

        public Carro(Usuario miembro )
        {
            _id = Guid.NewGuid().ToString();
            Articulos = new List<CantidadArticulo>();
            Consolas = new List<Consola>();
            Posters = new List<Poster>();
            Interesado = miembro;
        }

        public void AgregarArticulo(Articulo art,int stockArt)
        {
            CantidadArticulo guardar_art = new CantidadArticulo(art,stockArt);
            _articulos.Add(guardar_art);
        }


        public decimal PrecioDelCarro()
        {
            decimal result = 0;
            PrecioFinalArticulos(result);
            PrecioFinalConsolas(result);
            PrecioFinalPosters(result);
            return result;
        }

        private void PrecioFinalArticulos(decimal result)
        {
            foreach (CantidadArticulo art in _articulos)
            {

                result += art.ArticuloElegido.Precio;
            }
        }

        private void PrecioFinalPosters(decimal result)
        {
            foreach (Poster poster in _posters)
            {
                result += poster.Precio;
            }
        }

        private void PrecioFinalConsolas(decimal result)
        {
            foreach (Consola consola in _consolas)
            {
                result += consola.Precio;
            }
        }
    }
}
