using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public class Manga: Articulo
    {
        private bool _isImportado;

        public bool IsImportado { get { return _isImportado;} set { _isImportado = value; } }

        public Manga() : base() { PrecioFinal(); }

        public Manga(string titulo, string autor, int añopublicacion, decimal precio, bool isimportado,int stock,string imagen,string sinopsis) : base(titulo, autor, añopublicacion, precio, stock, imagen, sinopsis)
        {
            _isImportado = isimportado;
            PrecioFinal();
        }

        public override void PrecioFinal()
        {
            if (_isImportado)
            {
                Precio += Precio * (decimal)0.5;
            }
        }
    }
}
