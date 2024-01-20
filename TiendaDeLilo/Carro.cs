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
        private Usuario? _interesado;

        public string Id { get { return _id; }  }
        public Usuario? Interesado { get { return _interesado; } set { _interesado = value; } }
        public List<CantidadArticulo> Articulos { get { return _articulos; } }

        public Carro() { _id = Guid.NewGuid().ToString(); }

        public Carro(Usuario? miembro)
        {
            _id = Guid.NewGuid().ToString();
            _articulos = new List<CantidadArticulo>();
            Interesado = miembro;
        }

        public void AgregarArticulo(Articulo art,int stockArt)
        {
            CantidadArticulo guardar_art = new CantidadArticulo(art,stockArt);
            _articulos.Add(guardar_art);
        }

        public void CambiarCantidad(Articulo art, int stockArt)
        {
            int i = 0;
            while(i < _articulos.Count)
            {
                if (_articulos[i].ArticuloElegido.Equals(art))
                {
                    _articulos[i].CantidadArtic = stockArt;
                    return;
                }
                i++;
            }
            throw new Exception("El articulo no se encuentra en el carro");
        }


        public decimal PrecioDelCarro()
        {
            decimal result = 0;
            PrecioFinalArticulos(result);
            return result;
        }

        private void PrecioFinalArticulos(decimal result)
        {
            foreach (CantidadArticulo art in _articulos)
            {
                result += art.ArticuloElegido.Precio;
            }
        }

    }
}
