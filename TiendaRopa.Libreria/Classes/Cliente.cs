﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.Libreria.Classes
{
    public class Cliente
    {
        private int _codigo;
        private string _apellido;
        private string _nombre;

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
        }

        public int Codigo
        {
            get
            {
                return this._codigo;
            }
        }

        public Cliente(int codigo, string apellido, string nombre)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._codigo = codigo;
        }
    }
}
