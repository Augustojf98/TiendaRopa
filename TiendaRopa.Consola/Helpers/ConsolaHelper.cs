using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Consola.Helpers
{
    class ConsolaHelper
    {
        public static string PedirString(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            string s = Console.ReadLine();
            return s;
        }
        public static int PedirInt(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            int s = int.Parse(Console.ReadLine());
            return s;
        }
        public static double PedirDouble(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            double s = double.Parse(Console.ReadLine());
            return s;
        }
        public static bool PedirBool(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            bool b;
            string s = Console.ReadLine();
            if(s.ToUpper() == "1")
            {
                b = true;
            }
            else if(s.ToUpper() == "2")
            {
                b = false;
            }
            else
            {
                throw new Exception("El valor ingresado es inválido");
            }

            return b;
        }

        public static bool EsOpcionValida(string input, string opcionesValidas)
        {
            try
            {
                if (string.IsNullOrEmpty(input)
                    || input.Length > 1  
                    || !opcionesValidas.ToUpper().Contains(input.ToUpper()))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
