using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agencia
    {
        //PROPIEDADES
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        private static Agencia instancia = null;
        public List<Excursion> Excursiones { get; set; } = new List<Excursion>();
        public List<Destino> Destinos { get; set; } = new List<Destino>();
        public float CotizacionDolar { get; set; }
        public int ContadorIdentificadorExcursiones { get; set; } = 1000;
        public List<Compra> Compras { get; set; } = new List<Compra>();

        //CONSTRUCTOR
        private Agencia()
        {
            GenerarUsuariosPorDefecto();
            PrecargarDatos();
        }

        //ESTANCIA SINGLETON
        public static Agencia Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Agencia();
                }
                return instancia;
            }
        }

        //CONTROL DE USUARIOS
        public bool AgregarUsuario(Cliente xUsuario)
        {
            bool i = false;
            foreach (Usuario usuario in Usuarios)
            {
                if (usuario.NombreUsuario == xUsuario.NombreUsuario)
                {
                    i = true;
                }
            }
            if (!i)
            {
                Usuarios.Add(xUsuario);
                Usuarios.Sort();
                return true;
            }
            return false;
        }
        public bool EliminarUsuario(Usuario xUsuario)
        {
            for (int i = 0; i < Usuarios.Count; i++)
            {
                if (Usuarios[i] == xUsuario)
                {
                    Usuarios.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public Usuario BuscarUsuario(string xNombreUsuario, string xClave)
        {
            foreach (Usuario usuario in Usuarios)
            {
                if (usuario.NombreUsuario == xNombreUsuario && usuario.Clave == xClave)
                {
                    return usuario;
                }
            }
            return null;
        }
        public List<Usuario> RetornarUsuarios()
        {
            return Usuarios;
        }
        public void GenerarUsuariosPorDefecto()
        {
            Usuario administrador = new Administrador("Admin", "Francesco", "Frioni", "123");
            Usuario administrador2 = new Administrador("Administrador", "Juan", "Rodriguez", "123");
            Usuarios.Add(administrador);
            Usuarios.Add(administrador2);
        }

        //CONTROL DE DESTINOS
        public bool IngresarDestino(string Ciudad, string Pais, int CantidadDias, float CosteDiario)
        {
            if (Ciudad.Length < 3 || Pais.Length < 3 || CantidadDias < 1 || CosteDiario < 0 || CombinacionCiudadPais(Ciudad, Pais))
            {
                return false;
            }
            else
            {
                Destino destino = new Destino(Ciudad, Pais, CantidadDias, CosteDiario);
                Destinos.Add(destino);
                return true;
            }
        }
        public bool CombinacionCiudadPais(string Ciudad, string Pais)
        {
            foreach (Destino destino in Destinos)
            {
                if (Ciudad == destino.Ciudad && Pais == destino.Pais)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Destino> DestinosMasUsado()
        {
            int i = 0;
            int h = 0;
            List<Destino> DestinosARetornar = new List<Destino>();
            foreach (Destino destino in Destinos)
            {
                foreach (Excursion excursion in Excursiones)
                {
                    foreach (Destino des in excursion.Destinos)
                    {
                        if (des == destino)
                        {
                            i++;
                        }
                    }
                }
                if (i > h)
                {
                    h = i;
                    DestinosARetornar.Clear();
                    DestinosARetornar.Add(destino);
                } else if (i == h)
                {
                    DestinosARetornar.Add(destino);
                }
                i = 0;
            }
            return DestinosARetornar;
        }

        //CONTROL DE COTIZACION DOLAR
        public bool TestearCotizacionDolar(float CotizacionDolar)
        {
            if (CotizacionDolar < 0.01f)
            {
                return false;
            }
            else
            {
                this.CotizacionDolar = CotizacionDolar;
                return true;
            }
        }

        //CONTROL EXCRUSIONES
        public bool TestearExcursiones(List<Destino> Destinos)
        {
            for (int i = 0; i < Destinos.Count; i++)
            {
                for (int h = 0; h < Destinos.Count; h++)
                {
                    if (i != h)
                    {
                        if (Destinos[i] == Destinos[h])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool IngresarExcursionNacional(int Codigo, string Descripcion, DateTime FechaComienzo, List<Destino> Destinos, int DiasTotales, int Stock, bool InteresNacional)
        {
            bool nacional = true;
            if (Destinos.Count < 2 || TestearExcursiones(Destinos))
            {
                return false;
            }
            else
            {
                foreach (Destino destino in Destinos)
                {
                    if(destino.Pais != "Uruguay")
                    {
                        nacional = false;
                    }
                }
                if (nacional)
                {
                    Nacionales exc = new Nacionales(Codigo, Descripcion, FechaComienzo, Destinos, DiasTotales, Stock, InteresNacional, ContadorIdentificadorExcursiones);
                    ContadorIdentificadorExcursiones += 100;
                    Excursiones.Add(exc);
                    return true;
                }
                return false;
            }

        }
        public bool IngresarExcursionInternacional(int Codigo, string Descripcion, DateTime FechaComienzo, List<Destino> Destinos, int DiasTotales, int Stock, CompañiaAerea CompañiasAereas)
        {
            if (Destinos.Count < 2 || TestearExcursiones(Destinos))
            {
                return false;
            }
            else
            {
                Internacionales exc = new Internacionales(Codigo, Descripcion, FechaComienzo, Destinos, DiasTotales, Stock, CompañiasAereas, ContadorIdentificadorExcursiones);
                ContadorIdentificadorExcursiones += 100;
                Excursiones.Add(exc);
                return true;
            }
        }
        public int CalcularDiasExcursion(List<Destino> Destinos)
        {
            int totalDias = 0;
            foreach (Destino destino in Destinos)
            {
                totalDias += destino.CantidadDias;
            }
            return totalDias;
        }

        public float CalcularCostoExcursion(List<Destino> Destinos)
        {
            float totalCosto = 0;
            foreach (Destino destino in Destinos)
            {
                float costoDestino = destino.CantidadDias * destino.CosteDiario;
                totalCosto += costoDestino;
            }
            return totalCosto;
        }

        public List<Excursion> CalcularExcursionEntreFechas(int Destino, DateTime FechaInicio, DateTime FechaFinal)
        {
            List<Excursion> ExcursionesLimitadas = new List<Excursion>();
            List<Excursion> ExcursionesFinales = new List<Excursion>();
            foreach (Excursion excursion in Excursiones)
            {
                if (TestearDestinos((Destino - 1), excursion))
                {
                    ExcursionesLimitadas.Add(excursion);
                }
            }
            foreach (Excursion excursion in ExcursionesLimitadas)
            {
                if (excursion.FechaComienzo > FechaInicio && excursion.FechaComienzo < FechaFinal)
                {
                    ExcursionesFinales.Add(excursion);
                }
            }
            return ExcursionesFinales;
        }

        public bool TestearDestinos(int Destino, Excursion excursion)
        {
            foreach (Destino destino in excursion.Destinos)
            {
                if (Destinos[Destino] == destino)
                {
                    return true;
                }
            }
            return false;
        }

        public Excursion BuscarExcursionPorCodigo(int xCodigo)
        {
            foreach (Excursion excursion in Excursiones)
            {
                if(excursion.Codigo == xCodigo)
                {
                    return excursion;
                }
            }
            return null;
        }

        public List<Excursion> BuscarExcursionesPorDestino(int i)
        {
            List<Excursion> ExcursionesARetornar = new List<Excursion>();
            foreach (Excursion excursion in Excursiones)
            {
                foreach (Destino destino in excursion.Destinos)
                {
                    if(destino == Destinos[i])
                    {
                        ExcursionesARetornar.Add(excursion);
                    }
                }
            }
            return ExcursionesARetornar;
        }

        //PRECARGAR DATOS
        public void PrecargarDatos()
        {
            CotizacionDolar = 25;
            PrecargarDestinos();
            PrecargarExcursiones();
        }
        public void PrecargarDestinos()
        {
            IngresarDestino("Salto", "Uruguay", 5, 30);
            IngresarDestino("Paysandu", "Uruguay", 7, 35);
            IngresarDestino("Montevideo", "Uruguay", 10, 60);
            IngresarDestino("Colonia", "Uruguay", 6, 50);
            IngresarDestino("Rocha", "Uruguay", 6, 50);
            IngresarDestino("Nueva York", "Estados Unidos", 12, 100);
            IngresarDestino("Lima", "Peru", 7, 70);
            IngresarDestino("Caracas", "Venezuela", 5, 25);
            IngresarDestino("Buenos Aires", "Argentina", 8, 30);
            IngresarDestino("Rio de Janeiro", "Brasil", 10, 75);
        }
        public void PrecargarExcursiones()
        {
            List<Destino> Destinos1 = new List<Destino>();
            Destinos1.Add(Destinos[0]);
            Destinos1.Add(Destinos[1]);
            List<Destino> Destinos2 = new List<Destino>();
            Destinos2.Add(Destinos[0]);
            Destinos2.Add(Destinos[2]);
            List<Destino> Destinos3 = new List<Destino>();
            Destinos3.Add(Destinos[0]);
            Destinos3.Add(Destinos[3]);
            List<Destino> Destinos4 = new List<Destino>();
            Destinos4.Add(Destinos[0]);
            Destinos4.Add(Destinos[4]);
            List<Destino> Destinos5 = new List<Destino>();
            Destinos5.Add(Destinos[5]);
            Destinos5.Add(Destinos[6]);
            List<Destino> Destinos6 = new List<Destino>();
            Destinos6.Add(Destinos[6]);
            Destinos6.Add(Destinos[7]);
            List<Destino> Destinos7 = new List<Destino>();
            Destinos7.Add(Destinos[7]);
            Destinos7.Add(Destinos[8]);
            List<Destino> Destinos8 = new List<Destino>();
            Destinos8.Add(Destinos[8]);
            Destinos8.Add(Destinos[9]);
            IngresarExcursionNacional(1, "Viaje de Salto a Paysandu", new DateTime(2020, 12, 15), Destinos1, CalcularDiasExcursion(Destinos1), 100, false);
            IngresarExcursionNacional(2, "Viaje de Salto a Montevideo", new DateTime(2021, 4, 19), Destinos2, CalcularDiasExcursion(Destinos2), 110, false);
            IngresarExcursionNacional(3, "Viaje de Salto a Colonia", new DateTime(2021, 4, 20), Destinos3, CalcularDiasExcursion(Destinos3), 120, true);
            IngresarExcursionNacional(4, "Viaje de Salto a Rocha", new DateTime(2021, 4, 21), Destinos4, CalcularDiasExcursion(Destinos4), 130, true);
            IngresarExcursionInternacional(5, "Viaje Nueva York y Lima", new DateTime(2021, 4, 22), Destinos5, CalcularDiasExcursion(Destinos5), 140, new CompañiaAerea(10, "Uruguay"));
            IngresarExcursionInternacional(6, "Viaje Lima y Caracas", new DateTime(2021, 4, 23), Destinos6, CalcularDiasExcursion(Destinos6), 140, new CompañiaAerea(20, "Estados Unidos"));
            IngresarExcursionInternacional(7, "Viaje Caracas y Buenos Aires", new DateTime(2021, 4, 24), Destinos7, CalcularDiasExcursion(Destinos7), 140, new CompañiaAerea(30, "Peru"));
            IngresarExcursionInternacional(8, "Viaje Buenos Aires y Rio de Janeiro", new DateTime(2021, 4, 25), Destinos8, CalcularDiasExcursion(Destinos8), 140, new CompañiaAerea(40, "Argentina"));
        }
    }
}


