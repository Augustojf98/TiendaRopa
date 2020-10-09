using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Libreria.Classes
{
    public class IndumentariaCasual: TipoIndumentaria
    {
        public IndumentariaCasual(string origen, double porcentajeAlgodon)
        {
            this.Origen = origen;
            this.PorcentajeAlgodon = porcentajeAlgodon;
        }

        public string OrigenCasual
        {
            get
            {
                return this.Origen;
            }
            set
            {
                this.Origen = value;
            }
        }

        public double PorcentajeAlgodonCasual
        {
            get
            {
                return this.PorcentajeAlgodon;
            }
            set
            {
                this.PorcentajeAlgodon = value;
            }
        }
    }
}
