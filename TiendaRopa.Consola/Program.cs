using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Libreria.Classes.TiendaRopa Zara = new Libreria.Classes.TiendaRopa();
            
            bool continuarActivo = true;

            string menu = "1) Registrar Indumentaria \n2) Listar indumentaria \n3) Agregar Stock \n4) Modificar Indumentaria \n5) Eliminar Indumentaria" +
                " \n6) Vender Indumentaria \n7) Devolver Indumentaria \n8) Listar Ventas \n9) Limpiar pantalla \nX) Cerrar programa";
            
            Console.WriteLine("Bienvenido a Zara\n\nIngrese una opción del menú:");

            do
            {
                Console.WriteLine(menu);
                try
                {
                    string opcionSeleccionada = Console.ReadLine();

                    if(Helpers.ConsolaHelper.EsOpcionValida(opcionSeleccionada, "123456789X"))
                    {
                        if (opcionSeleccionada.ToUpper() == "X")
                        {
                            continuarActivo = false;
                            continue;
                        }
                        switch (opcionSeleccionada)
                        {
                            case "1":
                                RegistrarIndumentaria(Zara);
                                break;
                            case "2":
                                ListarIndumentaria(Zara);
                                break;
                            case "3":
                                break;
                            case "4":
                                break;
                            case "5":
                                break;
                            case "6":
                                break;
                            case "7":
                                break;
                            case "8":
                                break;
                            case "9":
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error durante la ejecución del comando. Por favor intente nuevamente. Mensaje: " + ex.Message);
                }
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                Console.Clear();
            }

            while (continuarActivo);

            Console.WriteLine("Gracias por usar la app.");
            Console.ReadKey();
        }



        private static void RegistrarIndumentaria(Libreria.Classes.TiendaRopa tiendaRopa)
        {
            try
            {
                string tipoIndumentaria = Helpers.ConsolaHelper.PedirString("Tipo de prenda (D - Deportiva | C - Casual | F - Formal)");
                if(Helpers.ConsolaHelper.EsOpcionValida(tipoIndumentaria, "DCF"))
                {
                    string tipoPrenda = Helpers.ConsolaHelper.PedirString("Tipo de indumentaria (P - Pantalón | C - Camisa)");
                    if(Helpers.ConsolaHelper.EsOpcionValida(tipoPrenda, "PC"))
                    {

                        string talle = Helpers.ConsolaHelper.PedirString("Talle");
                        double precio = Helpers.ConsolaHelper.PedirDouble("Precio");

                        string origen = Helpers.ConsolaHelper.PedirString("Origen");
                        double porcentajeAlgodon = Helpers.ConsolaHelper.PedirDouble("Porcentaje de algodón");

                        string tipoManga = string.Empty;
                        bool tieneEstampado = false;

                        if (tipoPrenda.ToUpper() == "C")
                        {
                            tipoManga = Helpers.ConsolaHelper.PedirString("Tipo de manga");
                            tieneEstampado = Helpers.ConsolaHelper.PedirBool("Si tiene estampado (1 - Sí | 2 - No)");
                        }

                        bool tieneBolsillos = false;
                        string material = string.Empty;

                        if (tipoPrenda.ToUpper() == "P")
                        {
                            material = Helpers.ConsolaHelper.PedirString("Material");
                            tieneBolsillos = Helpers.ConsolaHelper.PedirBool("Si tiene bolsillos (1 - Sí | 2 - No)");
                        }

                        tiendaRopa.AgregarIndumentaria(talle, precio, tipoPrenda, tipoIndumentaria, origen, porcentajeAlgodon, tieneBolsillos, tieneEstampado, material, tipoManga);
                    }
                    else
                    {
                        throw new Exception("El valor ingresado es inválido.");
                    }
                }
                else
                {
                    throw new Exception("El valor ingresado es inválido.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en uno de los datos ingresados. " + ex.Message + " Intente nuevamente. \n\n");

                bool quiereNuevamente = Helpers.ConsolaHelper.PedirBool("Si quiere intentar nuevamente (1 - Sí | 2 - No)");

                if(quiereNuevamente == true)
                {
                    RegistrarIndumentaria(tiendaRopa);
                }
            }
        }

        private static void ListarIndumentaria(Libreria.Classes.TiendaRopa tiendaRopa)
        {
            try
            {
                int cantidadPrendas = tiendaRopa.ListarIndumentarias().Count();

                for(int i = 0; i < cantidadPrendas; i++)
                {
                    Console.WriteLine(tiendaRopa.ListarIndumentarias()[i]);
                }
            }
            catch (Libreria.Exceptions.SinIndumentariaException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AgregarStock(Libreria.Classes.TiendaRopa tiendaRopa)
        {

        }

        private static void ModificarIndumentaria(Libreria.Classes.TiendaRopa tiendaRopa)
        {

        }

        private static void EliminarIndumentaria(Libreria.Classes.TiendaRopa tiendaRopa)
        {

        }

        private static void VenderIndumentaria(Libreria.Classes.TiendaRopa tiendaRopa)
        {

        }

        private static void DevolverIndumentaria(Libreria.Classes.TiendaRopa tiendaRopa)
        {

        }

        private static void ListarVentas(Libreria.Classes.TiendaRopa tiendaRopa)
        {
            tiendaRopa.ListarVentas();
        }
    }
}
