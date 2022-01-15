using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario : IComparable<Usuario>
    {
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }

        public int CompareTo(Usuario other)
        {
            return (this.Apellido + this.Nombre).CompareTo(other.Apellido + other.Nombre);
        }
    }
}
