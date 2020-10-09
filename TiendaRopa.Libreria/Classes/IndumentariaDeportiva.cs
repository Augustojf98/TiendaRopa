using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Libreria.Classes
{
    public class IndumentariaDeportiva: TipoIndumentaria
    {
        public IndumentariaDeportiva(string origen, double porcentajeAlgodon)
        {
            this.Origen = origen;
            this.PorcentajeAlgodon = porcentajeAlgodon;
        }

        public string OrigenDeportiva
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

        public double PorcentajeAlgodonDeportiva
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
