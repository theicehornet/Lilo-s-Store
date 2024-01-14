using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class Compra
    {
        private string _id;
        private List<Articulo> _articulos;
        private List<Consola> _consolas;
        private string _idmiembro;
        private List<Poster> _posters;

        public string Id { get { return _id; } }
        public string IdMiembro { get { return _idmiembro; } set { _idmiembro = value; } }
        public List<Articulo> Articulos { get { return _articulos; } set { _articulos = value; } }
        public List<Consola> Consolas { get { return _consolas; } set { _consolas = value; } }
        public List<Poster> Posters { get { return _posters; } set { _posters = value; } }

        public Compra() { _id = Guid.NewGuid().ToString(); }

        public Compra(List<Articulo> articulos, List<Consola> consolas, List<Poster> posters, string idMiembro)
        {
            _id = Guid.NewGuid().ToString();
            Articulos = articulos;
            Consolas = consolas;
            Posters = posters;
            IdMiembro = idMiembro;
        }

        public void Validar() {
            ValidarIdMiembro();
        }

        private void ValidarIdMiembro()
        {
            if (string.IsNullOrEmpty(_idmiembro))
                throw new Exception("Miembro no logueado/no registrado/no encontrado");
        }
    }
}
