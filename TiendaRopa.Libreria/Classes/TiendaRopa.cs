using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Libreria.Classes
{
    public class TiendaRopa
    {
        private List<Indumentaria> _inventario;
        private List<Venta> _ventas;
        private int _ultimoCodigo;

        public TiendaRopa()
        {
            this._inventario = new List<Indumentaria>();
            this._ventas = new List<Venta>();
        }

        public bool InventarioVacio
        {
            get
            {
                return this._inventario.Count() == 0;
            }
        }

        public bool SinVentas
        {
            get
            {
                return this._ventas.Count() == 0;
            }
        }

        public List<Indumentaria> Inventario
        {
            get
            {
                return this._inventario;
            }
        }

        public List<Venta> Ventas
        {
            get
            {
                return this._ventas;
            }
        }

        public void VenderItem(int codigoIndumentaria, int cantidad, int codCliente, string apeCliente, string nomCliente)
        {
            if (!InventarioVacio)
            {
                Indumentaria indumentaria = BuscarPorCodigo(codigoIndumentaria);
                if(indumentaria.GetStockActual != 0)
                {
                    if (indumentaria.GetStockActual >= cantidad)
                    {

                        int nuevoCodigo = this.GetUltimoCodigoVenta() + 1;

                        Venta venta = new Venta(nuevoCodigo, codCliente, apeCliente, nomCliente);
                        venta.AgregarItems(indumentaria, cantidad);
                        this.RetirarStock(codigoIndumentaria, cantidad);
                        venta.Estado = (int)Enums.EstadoVenta.Procesada;

                        _ventas.Add(venta);
                    }
                    else
                    {
                        throw new Exceptions.SinStockException("No hay suficiente stock de la indumentaria de código", string.Format("{0}", codigoIndumentaria));
                    }
                }
                else
                {
                    throw new Exceptions.SinStockException(string.Format("{0}", codigoIndumentaria));
                }
            }
            else
            {
                throw new Exceptions.SinIndumentariaException();
            }
        }

        public void DevolverItem(int codVenta, int codIndumentaria)
        {
            if (!SinVentas)
            {
                if (!InventarioVacio)
                {

                    Venta venta = BuscarVentaPorCodigo(codVenta);

                    if(venta != null)
                    {
                        if(venta.Estado != (int)Enums.EstadoVenta.Devuelto)
                        {
                            Indumentaria indumentaria = BuscarPorCodigo(codIndumentaria);

                            if (indumentaria != null)
                            {
                                VentaItem ventaItem = venta.BuscarPorCodigo(codIndumentaria);

                                if (ventaItem != null)
                                {
                                    venta.Items.Remove(ventaItem);

                                    AgregarStock(ventaItem.Prenda.Codigo, ventaItem.CantidadVendida);

                                    if (venta.Items.Count() == 0)
                                    {
                                        venta.Estado = (int)Enums.EstadoVenta.Devuelto;
                                    }
                                }
                                else
                                {
                                    throw new Exception("No existe ninguna prenda con el código " + codIndumentaria + " en la venta " + codVenta + ".");
                                }
                            }
                            else
                            {
                                throw new Exceptions.SinIndumentariaException(codIndumentaria);
                            }

                        }
                        else
                        {
                            throw new Exception("La venta ya fue devuelta.");
                        }
                    }
                    else
                    {
                        throw new Exception("No hay ninguna venta cargadas en el sistema con el código " + codVenta + ".");
                    }
                }
                else
                {
                    throw new Exceptions.SinIndumentariaException();
                }
            }
            else
            {
                throw new Exception("No hay ventas cargadas en el sistema aún.");
            }
        }

        public List<string> ListarVentas()
        {
            List<string> lv = new List<string>();

            if (!SinVentas)
            {
                foreach (Venta v in _ventas)
                {
                    lv.AddRange(v.GetDetalle());
                }
                return lv;
            }
            else
            {
                throw new Exception("No hay ventas registradas aún.");
            }
        }

        public List<string> ListarIndumentarias()
        {
            List<string> li = new List<string>();
            if (!InventarioVacio)
            {
                foreach (Indumentaria indumentaria in _inventario)
                {
                    li.Add(indumentaria.GetDetalle());
                }
                return li;
            }
            else
            {
                throw new Exceptions.SinIndumentariaException();
            }
        }

        public string ListarItemVenta()
        {
            if (!InventarioVacio)
            {
                if (!SinVentas)
                {
                    foreach(Venta v in _ventas)
                    {
                        foreach(VentaItem ventaItem in v.Items)
                        {
                            return string.Format("{0}", ventaItem.ToString());
                        }
                    }
                    return null;
                }
                else
                {
                    throw new Exception("No hay ventas registradas aún.");
                }
            }
            else
            {
                throw new Exceptions.SinIndumentariaException();
            }
        }

        public Venta BuscarVentaPorCodigo(int codigo)
        {
            if (!SinVentas)
            {
                foreach (Venta venta in _ventas)
                {
                    if (venta.Codigo == codigo)
                    {
                        if (venta.Estado == (int)Enums.EstadoVenta.Devuelto)
                        {
                            throw new Exception("La orden fue devuelta");
                        }
                        else
                        {
                            return venta;
                        }
                    }
                }
                return null;
            }
            else
            {
                throw new Exception("No hay ventas aún");
            }
        }

        public Indumentaria BuscarPorCodigo(int codigo)
        {
            if (!InventarioVacio)
            {
                foreach(Indumentaria indumentaria in _inventario)
                {
                    if(indumentaria.Codigo == codigo)
                    {
                        return indumentaria;
                    }
                }
                return null;
            }
            else
            {
                throw new Exceptions.SinIndumentariaException();
            }
        }

        public void AgregarIndumentaria(string talle, double precio, string tipoPrenda, string tipoIndumentariaElegida, string origen, double porcentajeAlgodon, bool tieneBolsillos, bool tieneEstampado, string material, string tipoManga)
        {
            Indumentaria indumentaria;
            TipoIndumentaria tipoIndumentaria;
            int ultimoCodigo = GetUltimoCodigoIndumentaria() + 1;

            switch (tipoPrenda.ToUpper())
            {
                case "P":
                    switch (tipoIndumentariaElegida.ToUpper())
                    {
                        case "D":
                            tipoIndumentaria = new IndumentariaDeportiva(origen, porcentajeAlgodon);
                            indumentaria = new Pantalon(ultimoCodigo, precio, talle, tieneBolsillos, material, tipoIndumentaria);
                            break;
                        case "F":
                            tipoIndumentaria = new IndumentariaFormal(origen, porcentajeAlgodon);
                            indumentaria = new Pantalon(ultimoCodigo, precio, talle, tieneBolsillos, material, tipoIndumentaria);
                            break;
                        case "C":
                            tipoIndumentaria = new IndumentariaCasual(origen, porcentajeAlgodon);
                            indumentaria = new Pantalon(ultimoCodigo, precio, talle, tieneBolsillos, material, tipoIndumentaria);
                            break;
                        default:
                            throw new Exception("No existe el tipo de indumentaria");
                    }
                    break;
                case "C":
                    switch (tipoIndumentariaElegida.ToUpper())
                    {
                        case "D":
                            tipoIndumentaria = new IndumentariaDeportiva(origen, porcentajeAlgodon);
                            indumentaria = new Camisa(ultimoCodigo, precio, talle, tieneEstampado, tipoManga, tipoIndumentaria);
                            break;
                        case "F":
                            tipoIndumentaria = new IndumentariaFormal(origen, porcentajeAlgodon);
                            indumentaria = new Camisa(ultimoCodigo, precio, talle, tieneEstampado, tipoManga, tipoIndumentaria);
                            break;
                        case "C":
                            tipoIndumentaria = new IndumentariaCasual(origen, porcentajeAlgodon);
                            indumentaria = new Camisa(ultimoCodigo, precio, talle, tieneEstampado, tipoManga, tipoIndumentaria);
                            break;
                        default:
                            throw new Exception("No existe el tipo de indumentaria");
                    }
                    break;
                default:
                    throw new Exception("No existe el tipo de prenda");
            }
            this._inventario.Add(indumentaria);
        }

        public void ModificarIndumentaria(int codigo, string talle, double precio, bool tieneBolsillos, bool tieneEstampado, string material, string tipoManga)
        {
            Indumentaria indumentaria = BuscarPorCodigo(codigo);

            if (!InventarioVacio)
            {
                if(indumentaria != null)
                {
                    indumentaria.Precio = precio;
                    indumentaria.Talle = talle;

                    if(indumentaria is Pantalon)
                    {
                        ((Pantalon)indumentaria).TieneBolsillos = tieneBolsillos;
                        ((Pantalon)indumentaria).Material = material; ;
                    }
                    if (indumentaria is Camisa)
                    {
                        ((Camisa)indumentaria).TieneEstampado = tieneEstampado;
                        ((Camisa)indumentaria).TipoManga = tipoManga; ;
                    }
                }
                else
                {
                    throw new Exceptions.SinIndumentariaException(codigo);
                }
            }
            else
            {
                throw new Exceptions.SinIndumentariaException();
            }
        }

        public void AgregarStock(int codigo, int stockAgregado)
        {
            if(!this.InventarioVacio)
            {
                if (this.BuscarPorCodigo(codigo) != null)
                {
                    this.BuscarPorCodigo(codigo).AgregarUnidadesStock(stockAgregado);
                }
                else
                {
                    throw new Exceptions.SinIndumentariaException(codigo);
                }
            }
            else
            {
                throw new Exceptions.SinIndumentariaException();
            }
        }

        public void RetirarStock(int codigo, int stockQuitado)
        {
            if (!this.InventarioVacio)
            {
                if (this.BuscarPorCodigo(codigo) != null)
                {
                    this.BuscarPorCodigo(codigo).RestarUnidadesStock(stockQuitado);
                }
                else
                {
                    throw new Exceptions.SinIndumentariaException(codigo);
                }
            }
            else
            {
                throw new Exceptions.SinIndumentariaException();
            }
        }

        public void EliminarIndumentaria(int codigo)
        {
            if (!this.InventarioVacio)
            {
                if (this.BuscarPorCodigo(codigo) != null)
                {
                    this._inventario.Remove(this.BuscarPorCodigo(codigo));
                }
                else
                {
                    throw new Exceptions.SinIndumentariaException(codigo);
                }
            }
            else
            {
                throw new Exceptions.SinIndumentariaException();
            }
        }

        private int GetUltimoCodigoIndumentaria()
        {
            if (!InventarioVacio)
            {
                return _inventario.LastOrDefault().Codigo;
            }
            else
            {
                return 0;
            }
        }

        private int GetUltimoCodigoVenta()
        {
            if (!SinVentas)
            {
                return _ventas.LastOrDefault().Codigo;
            }
            else
            {
                return 0;
            }
        }
    }
}
