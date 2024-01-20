using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class Compra
    {
        private readonly string _idCompra;
        private Carro _carro;
        private readonly decimal _precio;
        private bool _isCancelada;

        public string IdCompra { get { return _idCompra; } }
        public bool IsCancelada { get { return _isCancelada; } }
        public Carro Carro { get { return _carro; } set { _carro = value; } }
        public decimal Precio { get { return _precio; } }

        public Compra() { _idCompra = Guid.NewGuid().ToString(); }

        public Compra(Carro carro)
        {
            _carro = carro;
            _precio = carro.PrecioDelCarro();
            _idCompra = Guid.NewGuid().ToString();
            _isCancelada = false;
        }

        public void CambiarEstado()
        {
            if (_isCancelada)
                throw new Exception("No se puede cancelar la cancelacion de la compra");
            _isCancelada = true;
        }


        public decimal PrecioFinal()
        {
            return _carro.PrecioDelCarro();
        }

    }
}
