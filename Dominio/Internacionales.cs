using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Internacionales : Excursion
    {
        public CompañiaAerea CompañiaAerea { get; set; }

        public Internacionales(int Codigo, string Descripcion, DateTime FechaComienzo, List<Destino> Destinos, int DiasTotales, int Stock, CompañiaAerea CompañiaAerea, int Identificador)
        {
            this.Codigo = Codigo;
            this.Descripcion = Descripcion;
            this.FechaComienzo = FechaComienzo;
            this.Destinos = Destinos;
            this.DiasTotales = DiasTotales;
            this.Stock = Stock;
            this.CompañiaAerea = CompañiaAerea;
            this.Identificador = Identificador;
        }
    }
}
