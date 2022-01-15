using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario
    {
        public Administrador(string NombreUsuario, string Nombre, string Apellido, string Clave)
        {
            this.NombreUsuario = NombreUsuario;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Clave = Clave;
        }
    }
}
