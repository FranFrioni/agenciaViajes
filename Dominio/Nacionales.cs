using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Nacionales : Excursion
    {
        public bool InteresNacional { get; set; }

        public Nacionales(int Codigo, string Descripcion, DateTime FechaComienzo, List<Destino> Destinos, int DiasTotales, int Stock, bool InteresNacional, int Identificador)
        {
            this.Codigo = Codigo;
            this.Descripcion = Descripcion;
            this.FechaComienzo = FechaComienzo;
            this.Destinos = Destinos;
            this.DiasTotales = DiasTotales;
            this.Stock = Stock;
            this.InteresNacional = InteresNacional;
            this.Identificador = Identificador;
        }
    }
}
