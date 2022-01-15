using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace AppConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            int accion = 1;
            while (accion != 0)
            {
                MenuInicial();
                accion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (accion == 1)
                {
                    AgregarDestino();
                }
                else if (accion == 2)
                {
                    VisualizarDestinos(0);
                }
                else if (accion == 3)
                {
                    MostrarYModificarCotizacionDolar();
                }
                else if (accion == 4)
                {
                    VisualizarExcursiones();
                }
                else if (accion == 5)
                {
                    VisualizarExcursionesEntreFechas();
                }
            }
        }
        static public void MenuInicial()
        {
            Console.WriteLine("Bienvenido a nuestra agencia de viajes. A continuacion se listaran las opciones que se pueden elegir. Ingrese el numero correspondiente para proseguir.");
            Console.WriteLine("1) Ingresar un destino");
            Console.WriteLine("2) Visualizar todos los destinos disponibles");
            Console.WriteLine("3) Modificiar la cotizacion del dolar");
            Console.WriteLine("4) Listar todas las excursiones disponibles");
            Console.WriteLine("5) Listar todas las excursiones disponibles entre dos fechas y un destino");
            Console.WriteLine("0) Salir del programa");
        }
        static public void AgregarDestino()
        {
            Console.WriteLine("Ingresar ciudad del destino:");
            string Ciudad = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Ingresar pais del destino:");
            string Pais = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Ingresar cantidad de dias en el destino:");
            int CantidadDias = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Ingresar costo diario en el destino:");
            float CostoDiario = float.Parse(Console.ReadLine());
            Console.Clear();
            if (Agencia.Instancia.IngresarDestino(Ciudad, Pais, CantidadDias, CostoDiario))
            {
                Console.WriteLine("Destino agregado con exito. Aprete una tecla para volver");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                while (!Agencia.Instancia.IngresarDestino(Ciudad, Pais, CantidadDias, CostoDiario))
                {
                    Console.WriteLine("Recuerde que la ciudad y el pais debe contener al menos tres caracteres, la cantidad de dias debe ser mayor a 1, y el coste diario debe ser al menos 0 o mayor.");
                    Console.WriteLine("Ingresar ciudad del destino:");
                    Ciudad = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Ingresar pais del destino:");
                    Pais = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Ingresar cantidad de dias en el destino:");
                    CantidadDias = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Ingresar costo diario en el destino:");
                    CostoDiario = float.Parse(Console.ReadLine());
                    Console.Clear();
                }
                Agencia.Instancia.IngresarDestino(Ciudad, Pais, CantidadDias, CostoDiario);
                Console.WriteLine("Destino agregado con exito. Aprete una tecla para volver");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static public void VisualizarDestinos(int accion)
        {
            int i = 1;
            Console.WriteLine("Los destinos disponibles son:");
            foreach (Destino destino in Agencia.Instancia.Destinos)
            {
                Console.WriteLine(i + ")");
                Console.WriteLine("Ciudad: " + destino.Ciudad + " Pais: " + destino.Pais + " Cantidad de Dias: " + destino.CantidadDias + " Coste Diario: " + destino.CosteDiario);
                Console.WriteLine("Costo Total en Dolares: " + destino.CantidadDias * destino.CosteDiario + " Costo Total en Pesos: " + destino.CantidadDias * destino.CosteDiario * Agencia.Instancia.CotizacionDolar);
                i++;
            }
            if (accion == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Aprete una tecla para volver");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static public void MostrarYModificarCotizacionDolar()
        {
            Console.WriteLine("La cotizacion del dolar actual es de: " + Agencia.Instancia.CotizacionDolar);
            Console.WriteLine("Si desea cambiar la cotizacion del dolar ingrese 'Si', de no querer hacerlo ingrese 'No'");
            string accion = Console.ReadLine();
            if (accion == "No")
            {
                Console.Clear();
                return;
            }
            else if (accion == "Si")
            {
                Console.Clear();
                Console.WriteLine("Ingresar la nueva cotizacion");
                float nuevaCotizacion = float.Parse(Console.ReadLine());
                Console.Clear();
                if (Agencia.Instancia.TestearCotizacionDolar(nuevaCotizacion))
                {
                    Console.WriteLine("La cotizacion del dolar fue cambiada con exito. Aprete una tecla para volver");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    while (!Agencia.Instancia.TestearCotizacionDolar(nuevaCotizacion))
                    {
                        Console.Clear();
                        Console.WriteLine("Necesita ingresar una cotizacion positiva");
                        Console.WriteLine("Ingresar la nueva cotizacion");
                        nuevaCotizacion = float.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    Agencia.Instancia.TestearCotizacionDolar(nuevaCotizacion);
                    Console.WriteLine("La cotizacion del dolar fue cambiada con exito. Aprete una tecla para volver");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static public void VisualizarExcursiones()
        {
            int i = 1;
            Console.WriteLine("Las excursiones disponibles son:");
            foreach (Excursion excursion in Agencia.Instancia.Excursiones)
            {
                int h = 1;
                Console.WriteLine(i + ")");
                Console.WriteLine("Codigo: " + excursion.Codigo + " Descripcion: " + excursion.Descripcion + " Fecha Comienzo: " + excursion.FechaComienzo + " Dias Totales: " + excursion.DiasTotales + " Stock: " + excursion.Stock + " Identificador: " + excursion.Identificador);
                Console.WriteLine("Destinos: ");
                foreach (Destino destino in excursion.Destinos)
                {

                    Console.WriteLine("     " + h + ".");
                    Console.WriteLine("     Ciudad: " + destino.Ciudad + " Pais: " + destino.Pais + " Cantidad de Dias: " + destino.CantidadDias + " Coste Diario: " + destino.CosteDiario);
                    Console.WriteLine("     Costo Total en Dolares: " + destino.CantidadDias * destino.CosteDiario + " Costo Total en Pesos: " + destino.CantidadDias * destino.CosteDiario * Agencia.Instancia.CotizacionDolar);
                    h++;
                }
                Console.WriteLine();
                Console.WriteLine("Costo total de excursion en Dolares: " + Agencia.Instancia.CalcularCostoExcursion(excursion.Destinos) + " Costo total de excursion en pesos: " + Agencia.Instancia.CalcularCostoExcursion(excursion.Destinos) * Agencia.Instancia.CotizacionDolar);
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Aprete una tecla para volver");
            Console.ReadKey();
            Console.Clear();
        }

        static public void VisualizarExcursionesEntreFechas()
        {
            Console.WriteLine("Ingresar destino que quiere utlizar (Debe ingresar el numero de dicho destino)");
            Console.WriteLine();
            VisualizarDestinos(1);
            Console.WriteLine();
            int destNum = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Ingresar año de inicio. Ej: 2021");
            int añoI = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingresar mes de inicio. Ej: 6");
            int mesI = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingresar dia de inicio. Ej: 12");
            int diaI = Convert.ToInt32(Console.ReadLine());
            DateTime FechaInicio = new DateTime(añoI, mesI, diaI);
            Console.Clear();
            Console.WriteLine("Ingresar año de fin. Ej: 2021");
            int añoF = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingresar mes de fin. Ej: 6");
            int mesF = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingresar dia de fin. Ej: 12");
            int diaF = Convert.ToInt32(Console.ReadLine());
            DateTime FechaFinal = new DateTime(añoF, mesF, diaF);
            Console.Clear();
            List<Excursion> Excursiones = new List<Excursion>(Agencia.Instancia.CalcularExcursionEntreFechas(destNum, FechaInicio, FechaFinal));
            int i = 1;
            Console.WriteLine("Las excursiones disponibles son:");
            foreach (Excursion excursion in Excursiones)
            {
                int h = 1;
                Console.WriteLine(i + ")");
                Console.WriteLine("Codigo: " + excursion.Codigo + " Descripcion: " + excursion.Descripcion + " Fecha Comienzo: " + excursion.FechaComienzo + " Dias Totales: " + excursion.DiasTotales + " Stock: " + excursion.Stock + " Identificador: " + excursion.Identificador);
                Console.WriteLine("Destinos: ");
                foreach (Destino destino in excursion.Destinos)
                {

                    Console.WriteLine("     " + h + ".");
                    Console.WriteLine("     Ciudad: " + destino.Ciudad + " Pais: " + destino.Pais + " Cantidad de Dias: " + destino.CantidadDias + " Coste Diario: " + destino.CosteDiario);
                    Console.WriteLine("     Costo Total en Dolares: " + destino.CantidadDias * destino.CosteDiario + " Costo Total en Pesos: " + destino.CantidadDias * destino.CosteDiario * Agencia.Instancia.CotizacionDolar);
                    h++;
                }
                Console.WriteLine();
                Console.WriteLine("Costo total de excursion en Dolares: " + Agencia.Instancia.CalcularCostoExcursion(excursion.Destinos) + " Costo total de excursion en pesos: " + Agencia.Instancia.CalcularCostoExcursion(excursion.Destinos) * Agencia.Instancia.CotizacionDolar);
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Aprete una tecla para volver");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
