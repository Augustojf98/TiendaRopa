using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaRopa.Libreria.Classes;

namespace TiendaRopa.Libreria
{
    public abstract class Indumentaria
    {
        private TipoIndumentaria _tipoIndumentaria;
        private int _codigo;
        private int _stock;
        private string _talle;
        private double _precio;

        public TipoIndumentaria TipoIndumentaria
        {
            get
            {
                return this._tipoIndumentaria;
            }
            set
            {
                this._tipoIndumentaria = value;
            }
        }

        public int Codigo
        {
            get
            {
                return this._codigo;
            }
            set
            {
                this._codigo = value;
            }
        }

        public int GetStockActual
        {
            get
            {
                return this._stock;
            }
        }

        public void AgregarUnidadesStock(int stockAgregado)
        {
            this._stock = this._stock + stockAgregado;
        }

        public void RestarUnidadesStock(int stockRestado)
        {
            this._stock = this._stock - stockRestado;
        }

        public string Talle
        {
            get
            {
                return this._talle;
            }
            set
            {
                this._talle = value;
            }
        }

        public double Precio
        {
            get
            {
                return this._precio;
            }
            set
            {
                this._precio = value;
            }
        }

        public override string ToString()
        {
            return GetDetalle();
        }

        public abstract string GetDetalle();

        public override bool Equals(object obj)
        {
            Indumentaria indumentaria = (Indumentaria)obj;

            return this._codigo == indumentaria.Codigo;
        }
    }
}
