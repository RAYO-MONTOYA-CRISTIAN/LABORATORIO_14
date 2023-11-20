using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = Pantallas.Menu();
            do
            {
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        opcion = Pantallas.EncuestaVacunacion();
                        break;
                    case 2:
                        opcion = Pantallas.DatosEncuesta();
                        break;
                    case 3:
                        opcion = Pantallas.MostrarResultados();
                        break;
                    case 4:
                        opcion = Pantallas.BuscarPersona();
                        break;
                    case 0:
                    default:
                        opcion = Pantallas.Menu();
                        break;
                }
            } while (opcion != 5);

        }
    }
}
