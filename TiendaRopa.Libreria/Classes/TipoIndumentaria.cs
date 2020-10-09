using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Libreria.Classes
{
    public abstract class TipoIndumentaria
    {
        private string _origen;
        private double _porcentajeAlgodon;

        public string Origen
        {
            get
            {
                return this._origen;
            }
            set
            {
                this._origen = value;
            }
        }

        public double PorcentajeAlgodon
        {
            get
            {
                return this._porcentajeAlgodon;
            }
            set
            {
                this._porcentajeAlgodon = value;
            }
        }

    }
}
