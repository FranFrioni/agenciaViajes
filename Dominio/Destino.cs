using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Destino
    {
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public int CantidadDias { get; set; }
        public float CosteDiario { get; set; }

        public Destino(string Ciudad, string Pais, int CantidadDias, float CosteDiario)
        {
            this.Ciudad = Ciudad;
            this.Pais = Pais;
            this.CantidadDias = CantidadDias;
            this.CosteDiario = CosteDiario;
        }
    }
}
