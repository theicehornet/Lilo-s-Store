using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class Compra
    {
        private string _idCompra;
        private Carro _carro;

        public string IdCompra { get { return _idCompra; } }
        public Carro Carro { get { return _carro; } set { _carro = value; } }

        public Compra() { }

        public Compra(Carro carro)
        {
            _carro = carro;
            _idCompra = Guid.NewGuid().ToString();
        }

        public decimal PrecioFinal()
        {
            return _carro.PrecioDelCarro();
        }

    }
}
