using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Excursion
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaComienzo { get; set; }
        public List<Destino> Destinos { get; set; }
        public int DiasTotales { get; set; }
        public int Stock { get; set; }
        public int Identificador { get; set; }
    }
}
