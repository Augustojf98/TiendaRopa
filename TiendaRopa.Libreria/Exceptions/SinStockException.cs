using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Libreria.Exceptions
{
    public class SinStockException: Exception
    {
        public SinStockException()
        {

        }

        public SinStockException(string msg)
            : base(String.Format("No hay stock para la indumentaria de código: {0}", msg))
        {

        }

        public SinStockException(string msg, string codigo)
            : base(String.Format("{0}: {1}", msg, codigo))
        {

        }
    }
}
