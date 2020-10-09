using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Libreria.Classes
{
    class Pantalon: Indumentaria
    {
        private bool _tieneBolsillos;
        private string _material;

        public bool TieneBolsillos
        {
            get
            {
                return this._tieneBolsillos;
            }
            set
            {
                this._tieneBolsillos = value;
            }
        }

        public string Material
        {
            get
            {
                return this._material;
            }
            set
            {
                this._material = value;
            }
        }

        public Pantalon(int codigo, double precio, string talle, bool tieneBolsillos, string material, TipoIndumentaria tipoIndumentaria)
        {
            this._tieneBolsillos = tieneBolsillos;
            this._material = material;
            this.Codigo = codigo;
            this.Talle = talle;
            this.TipoIndumentaria = tipoIndumentaria;
            this.AgregarUnidadesStock(3);
        }

        public Pantalon(int codigo, string talle, bool tieneBolsillos, string material, TipoIndumentaria tipoIndumentaria, int stock)
        {
            this._tieneBolsillos = tieneBolsillos;
            this._material = material;
            this.Codigo = codigo;
            this.Talle = talle;
            this.TipoIndumentaria = tipoIndumentaria;
            this.AgregarUnidadesStock(stock);
        }

        public override string GetDetalle()
        {
            if (this._tieneBolsillos == false)
                return string.Format("PANTALÓN - Material: {0} - Código: {1} - Talle: {2} - Precio: ${3} - Porcentaje de Algodón: {4} - Stock: {5} unidades - Origen: {6}.", this._material, this.Codigo, this.Talle, this.Precio, this.TipoIndumentaria.PorcentajeAlgodon, this.GetStockActual, this.TipoIndumentaria.Origen);
            else
                return string.Format("PANTALÓN CON BOLSILLOS- Material: {0} - Código: {1} - Talle: {2} - Precio: ${3} - Porcentaje de Algodón: {4} - Stock: {5} unidades - Origen: {6}.", this._material, this.Codigo, this.Talle, this.Precio, this.TipoIndumentaria.PorcentajeAlgodon, this.GetStockActual, this.TipoIndumentaria.Origen);
        }
    }
}
