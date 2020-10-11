using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Libreria.Classes
{
    public class Venta
    {
        private List<VentaItem> _items;
        private Cliente _cliente;
        private int _estado;
        private int _codigo;

        public Venta(int codigo, int codCliente, string apeCliente, string nomCliente)
        {
            var estadoInicial = (int)Enums.EstadoVenta.Iniciada;
            this._codigo = codigo;
            this._estado = estadoInicial;
            this._items = new List<VentaItem>();
            this._cliente = new Cliente(codCliente, apeCliente, nomCliente);
        }

        public int Estado
        {
            get
            {
                return this._estado;
            }
            set
            {
                this._estado = value;
            }
        }

        public List<VentaItem> Items
        {
            get
            {
                return this._items;
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

        public VentaItem BuscarPorCodigo(int codigo)
        {
            foreach (VentaItem item in _items)
            {
                if (item.Prenda.Codigo == codigo)
                {
                    return item;
                }
            }
            return null;
        }

        public void AgregarItems(Indumentaria indumentaria, int cantidad)
        {
            this._items.Add(new VentaItem(indumentaria, cantidad));
        }

        public double GetTotalPedido()
        {
            int cantidadVentas = this._items.Count();

            double dineroTotal = 0;

            for(int i = 0; i < cantidadVentas; i++)
            {
                dineroTotal = dineroTotal + this._items[i].GetTotal();
            }

            return dineroTotal;
        }

        public List<string> GetDetalle()
        {
            List<string> lv = new List<string>();

            if(this.Estado == (int)Enums.EstadoVenta.Procesada)
            {
                lv.Add(string.Format("Código venta: {0} - Cliente: {1} {2} ({3} - PROCESADA)", this._codigo, this._cliente.Nombre, this._cliente.Apellido, this._cliente.Codigo));
            }
            else if (this.Estado == (int)Enums.EstadoVenta.Devuelto)
            {
                lv.Add(string.Format("Código venta: {0} - Cliente: {1} {2} ({3} - DEVUELTA)", this._codigo, this._cliente.Nombre, this._cliente.Apellido, this._cliente.Codigo));
            }

            foreach (VentaItem vi in _items)
            {
                lv.Add(string.Format("Código de prenda: {0} - Cantidad vendida: {1}", vi.Prenda.Codigo, vi.CantidadVendida));
            }

            lv.Add("\n");

            return lv;
        }

    }
}
