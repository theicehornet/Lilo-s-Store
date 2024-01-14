using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public abstract class Usuario : IValidable
    {
        private string _id;
        private string _numeroCelular;
        private string _correo;
        private string _contraseña;

        /*
        fechaNacimiento <- camelCase
        fecha_nacimiento <- snake_case
        FechaNacimiento <- PascalCase
        */

        public string Id { get { return _id; } }
        public string NumeroCelular { get { return _numeroCelular; } set { _numeroCelular = value; } }
        public string Correo { get { return _correo; } set { _correo = value; } }
        public string Contraseña { get { return _contraseña; } set { _contraseña = value; } }

        public Usuario() { _id = Guid.NewGuid().ToString(); }

        public Usuario(string numerocel, string correo, string contra) 
        {
            
            _numeroCelular = numerocel;
            _correo = correo;
            _contraseña = contra;
        }

        public virtual void Validar()
        {
            ValidarCorreo();
            ValidarPassword();
            ValidarCelular();
        }

        public void ValidarCorreo()
        {
            if (String.IsNullOrEmpty(_correo)) throw new Exception("El correo no puede estar vacío");
        }

        public void ValidarPassword()
        {
            if (string.IsNullOrEmpty(_contraseña)) throw new Exception("La contraseña no puede estar vacía");
            if (_contraseña.Length < 5) throw new Exception("La contraseña debe tener una longitud mayor a cinco");
        }

        public void ValidarCelular()
        {
            if (string.IsNullOrEmpty(_numeroCelular)) throw new Exception("El celular no puede estar vacío");
            if (_numeroCelular.Length < 8) throw new Exception("El número telefonico debe tener al menos 9 números");
        }

        public override bool Equals(object? obj)
        {
            return obj is Usuario u && u.Correo.Equals(Correo);
        }
    }
}
