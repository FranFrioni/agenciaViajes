﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CompañiaAerea
    {
        public int Codigo { get; set; }
        public string Pais { get; set; }

        public CompañiaAerea(int Codigo, string Pais)
        {
            this.Codigo = Codigo;
            this.Pais = Pais;
        }
    }
}
