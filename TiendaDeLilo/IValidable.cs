using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeLilo
{
    public interface IValidable
    {
        public  void Validar();
        public void ValidarCorreo();
        public void ValidarPassword();
        public void ValidarCelular();
    }
}
