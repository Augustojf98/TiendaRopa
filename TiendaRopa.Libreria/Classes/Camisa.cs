using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Libreria.Classes
{
    public class Camisa: Indumentaria
    {
        private bool _tieneEstampado;
        private string _tipoManga;

        public bool TieneEstampado
        {
            get
            {
                return this._tieneEstampado;
            }
            set
            {
                this._tieneEstampado = value;
            }
        }

        public string TipoManga
        {
            get
            {
                return this._tipoManga;
            }
            set
            {
                this._tipoManga = value;
            }
        }


        public Camisa(int codigo, double precio, string talle, bool tieneEstampado, string tipoManga, TipoIndumentaria tipoIndumentaria)
        {
            this._tieneEstampado = tieneEstampado;
            this._tipoManga = tipoManga;
            this.Codigo = codigo;
            this.Talle = talle;
            this.Precio = precio;
            this.TipoIndumentaria = tipoIndumentaria;
            this.AgregarUnidadesStock(3);
        }

        public Camisa(int codigo, double precio, string talle, bool tieneEstampado, string tipoManga, TipoIndumentaria tipoIndumentaria, int stock)
        {
            this._tieneEstampado = tieneEstampado;
            this._tipoManga = tipoManga;
            this.Codigo = codigo;
            this.Talle = talle;
            this.Precio = precio;
            this.TipoIndumentaria = tipoIndumentaria;
            this.AgregarUnidadesStock(stock);
        }

        public override string GetDetalle()
        {
            if(this._tieneEstampado == false)
                return string.Format("CAMISA - Tipo de Manga: {0} - Código: {1} - Talle: {2} - Precio: ${3} - Porcentaje de Algodón: {4} - Stock: {5} unidades - Origen: {6}.", this._tipoManga, this.Codigo, this.Talle, this.Precio, this.TipoIndumentaria.PorcentajeAlgodon, this.GetStockActual, this.TipoIndumentaria.Origen);
            else
                return string.Format("CAMISA ESTAMPADA- Tipo de Manga: {0} - Código: {1} - Talle: {2} - Precio: ${3} - Porcentaje de Algodón: {4} - Stock: {5} unidades - Origen: {6}.", this._tipoManga, this.Codigo, this.Talle, this.Precio, this.TipoIndumentaria.PorcentajeAlgodon, this.GetStockActual, this.TipoIndumentaria.Origen);
        }
    }
}
