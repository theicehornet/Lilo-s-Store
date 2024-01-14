using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class Administrador : Usuario
    {
        private string _alias;

        public string Alias { get { return _alias; } set { _alias = value; } }

        public Administrador() : base() { }

        public Administrador(string numerocel, string correo, string contra, string alias) :base(numerocel,correo,contra)
        {
            _alias = alias;
        }

        public override void Validar()
        {
            base.Validar();
            ValidarAlias();
        }

        private void ValidarAlias()
        {
            if (string.IsNullOrEmpty(Alias))
                throw new Exception("El alias no puede estar vacío!");
        }

    }
}
