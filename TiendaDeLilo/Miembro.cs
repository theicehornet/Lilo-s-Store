using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class Miembro : Usuario
    {
        private string _nombre;
        private string _apellido;
        private DateTime _fechaNacimiento;

        public string Nombre { get { return _nombre; } set { _nombre = value; } }

        public string Apellido { get { return _apellido; } set { _apellido = value; } }

        public DateTime FechaNacimiento { get { return _fechaNacimiento; } set { _fechaNacimiento = value; } }

        public Miembro() : base() { } 

        public Miembro(string nombre, string apellido, DateTime fechanacimiento, string numerocel, string correo, string contra) : base(numerocel, correo, contra)
        {
            _nombre = nombre;
            _apellido = apellido;
            _fechaNacimiento = fechanacimiento;
        }

        public override void Validar()
        {
            base.Validar();
            ValidarNombre();
            ValidarApellido();
            ValidarFechaNacimiento();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_nombre))
                throw new Exception("El nombre no puede estar vacio");
        }

        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(_apellido))
                throw new Exception("El apellido no puede estar vacio");
        }

        private void ValidarFechaNacimiento()
        {
            if (_fechaNacimiento > DateTime.Now)
                throw new Exception("La fecha no puede ser mayor a la actual!");
        }

        public bool IsMayorEdad()
        {
            return DateTime.Now.Year - _fechaNacimiento.Year >= 18;
        }

    }
}
