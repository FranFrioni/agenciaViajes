using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public Excursion ExcursionComprada { get; set; }
        public int PasajesDeMayores { get; set; }
        public int PasajesDeMenores { get; set; }
        public Usuario Usuario { get; set; }
        public float PrecioCompra { get; set; }
        public DateTime FechaDeCompra { get; set; }
        public Compra(Excursion ExcursionComprada, int PasajesDeMayores, int PasajesDeMenores, Usuario Usuario)
        {
            this.ExcursionComprada = ExcursionComprada;
            this.PasajesDeMayores = PasajesDeMayores;
            this.PasajesDeMenores = PasajesDeMenores;
            this.Usuario = Usuario;
            this.FechaDeCompra = DateTime.Today;
            float i = 0;
            foreach (Destino destino in ExcursionComprada.Destinos)
            {
                i += (destino.CosteDiario * destino.CantidadDias);
            }
            i *= (PasajesDeMayores + PasajesDeMenores);
            this.PrecioCompra = i;
        }
    }
}
