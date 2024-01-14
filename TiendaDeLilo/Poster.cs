using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TiendaDeLilo
{
    public class Poster
    {
        private string _titulo;
        private string _imagen;
        private decimal _precio;
        private readonly string _id;
        private int _stock;

        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string Imagen { get { return _imagen; } set { _imagen = value; } }
        public decimal Precio { get { return _precio; } set { _precio = value; } }
        public string Id { get { return _id; } }
        public int Stock { get { return _stock; } set { _stock = value; } }

        public Poster() => _id = Guid.NewGuid().ToString();

        public Poster(string titulo, string imagen, decimal precio,int stock)
        {
            _titulo = titulo;
            _imagen = imagen;
            _precio = precio;
            _stock = stock;
        }

        public void Validar() 
        {
            ValidarTitulo();
            ValidarImagen();
        }

        private void ValidarTitulo()
        {
            if (string.IsNullOrEmpty(Titulo))
                throw new Exception("El titulo no puede estar vacío");
        }

        private void ValidarImagen()
        {
            if (string.IsNullOrEmpty(Imagen))
                throw new Exception("La imagen no puede estar vacío");
            if (!_imagen.StartsWith("https") && !_imagen.StartsWith("http"))
                throw new Exception("La imagen debe estar alojada en una url segura");

        }

        public override bool Equals(object? obj)
        {
            return obj is Poster other && other.Titulo.Equals(Titulo) && other.Imagen.Equals(Imagen);
        }

    }
}
