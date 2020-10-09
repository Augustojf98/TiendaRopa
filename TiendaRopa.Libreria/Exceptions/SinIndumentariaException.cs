using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Libreria.Exceptions
{
    public class SinIndumentariaException: Exception
    {
        public SinIndumentariaException() : base("No hay indumentaria cargada en el sistema aún")
        {

        }

        public SinIndumentariaException(int cod) : base("No hay indumentaria cargada en el sistema con el código: " + cod)
        {

        }
    }
}
