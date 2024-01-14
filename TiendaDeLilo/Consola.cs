using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class Consola
    {
        private string _id;
        private string _nombre;
        private string _creador;
        private bool _esPortatil;
        private decimal _precio;
        private int _stock;

        public string Id { get { return _id; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Creador { get { return _creador; } set { _creador = value; } }
        public bool EsPortatil { get {  return _esPortatil; } set {_esPortatil = value; } }
        public decimal Precio { get { return _precio; } set { _precio = value; } }
        public int Stock { get { return _stock; } set { _stock = value; } }

        public Consola() => _id = Guid.NewGuid().ToString();

        public Consola(string nombre, string creador, bool esPortatil, decimal precio, int stock)
        {

            Nombre = nombre;
            Creador = creador;
            EsPortatil = esPortatil;
            Precio = precio;
            _stock = stock;
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarCreador();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre de la consola no puede estar vacía");
        }

        private void ValidarCreador()
        {
            if (string.IsNullOrEmpty(_creador)) throw new Exception("El nombre del creador no puede estar vacía");
        }

        public override bool Equals(object? obj)
        {
            return obj is Consola c && c.Nombre.Equals(Nombre);
        }
    }
}
