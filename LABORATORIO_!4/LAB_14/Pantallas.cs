using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_14
{
    public class Pantallas
    {
        public static int[] edad = new int[1000];
        public static int[] voto = new int[1000];
        public static int contador = 0;
        public static int Menu()
        {
            string texto = "================================\n" +
                   "Encuesta Covid-19\n" +
                   "================================\n" +
                   "1: Realizar Encuesta\n" +
                   "2: Mostrar Datos de la encuesta\n" +
                   "3: Mostrar Resultados\n" +
                   "4: Buscar Personas por edad\n" +
                   "5: Salir\n" +
                   "================================\n";
            Console.Write(texto);
            return Operaciones.getEntero("Ingrese una opción: ", texto);
        }
        public static int EncuestaVacunacion()

        {
            string texto = " ================================\n" +
                "Encuesta de vacunación\n" +
                "================================\n";
            Console.Write(texto);
            int EDAD = Operaciones.getENTERO("¿Qué edad tienes: ");
            if (contador == 1000)
            {
                Console.WriteLine("LA LISTA YA ESTÁ LLENA");
            }
            else
            {
                string texto2 = "Te has vacunado\n" +
                "1: Sí\n" +
                "2: No\n" +
                "================================\n";
                Console.Write(texto2);
                int VOTO;
                do
                {
                    VOTO = Operaciones.getENTERO("Ingrese una opción: ");

                    if (VOTO != 1 && VOTO != 2)
                    {
                        Console.WriteLine("Ingresa una opción valida");
                    }
                } while (VOTO != 1 && VOTO != 2);

                edad[contador] = EDAD;
                voto[contador] = VOTO;
                contador++;
            }

            Console.Clear();
            return GraciasPorParticipar();
        }
        public static int GraciasPorParticipar()
        {
            string texto = " ================================\n" +
                "Encuesta de vacunación\n" +
                "================================\n" +
                " \n" +
                " \n" +
                "¡Gracias por participar!\n" +
                " \n" +
                " \n" +
                "================================\n" +
                "1: Regresar al menú\n" +
                "================================\n";
            Console.Write(texto);
            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
        public static int DatosEncuesta()
        {
            string texto = "================================\n" +
              "Datos de la encuesta\n" +
              "================================\n" +
              " \n" +
              "  ID |\tEdad |\tVacunado\n" +
              "================================\n";
            Console.Write(texto);

            if (contador == 0)
            {
                Console.WriteLine("No extisten notas");
            }
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{i.ToString("D4")} | {edad[i].ToString().PadLeft(4)}  | {(voto[i] == 1 ? "Si" : "No").PadRight(2)}");
            }

            string texto2 = "================================\n" +
              "1: Regresar\n" +
              "================================\n";
            Console.Write(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
        public static int MostrarResultados()
        {
            string texto = "================================\n" +
              "Resultados de la encuesta\n" +
              "================================\n";
            Console.Write(texto);

            int[] conteoPorOpcion = new int[3];
            int[] conteoPorEdad = new int[7];

            for (int i = 0; i < contador; i++)
            {
                int OPCION = voto[i];
                conteoPorOpcion[OPCION]++;

                int EDAD = edad[i];

                if (EDAD >= 1 && EDAD <= 20)
                {
                    conteoPorEdad[1]++;
                }
                else if (EDAD >= 21 && EDAD <= 30)
                {
                    conteoPorEdad[2]++;
                }
                else if (EDAD >= 31 && EDAD <= 40)
                {
                    conteoPorEdad[3]++;
                }
                else if (EDAD >= 41 && EDAD <= 50)
                {
                    conteoPorEdad[4]++;
                }
                else if (EDAD >= 51 && EDAD <= 60)
                {
                    conteoPorEdad[5]++;
                }
                else if (EDAD > 60)
                {
                    conteoPorEdad[6]++;
                }
            }

            string texto2 = $"{conteoPorOpcion[1]} personas se han vacunado\n" +
              $"{conteoPorOpcion[2]} personas no se han vacunado\n" +
              " \n" +
              "Existen:\n" +
              $"{conteoPorEdad[1]} personas entre 01 y 20 años\n" +
              $"{conteoPorEdad[2]} personas entre 21 y 30 años\n" +
              $"{conteoPorEdad[3]} personas entre 31 y 40 años\n" +
              $"{conteoPorEdad[4]} personas entre 41 y 50 años\n" +
              $"{conteoPorEdad[5]} personas entre 51 y 60 años\n" +
              $"{conteoPorEdad[6]} personas de más de 61 años\n" +
              "================================\n" +
              "1: Regresar\n" +
              "================================\n";
            Console.Write(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
        public static int BuscarPersona()
        {
            string texto = "================================\n" +
              "Busca a personas por edad\n" +
              "================================\n";
            Console.Write(texto);

            int valorBuscar = Operaciones.getENTERO("¿Qué edad quieres buscar?: ");
            int vacunados = 0;
            int noVacunados = 0;
            bool numeroEncontrado = false;

            for (int i = 0; i < contador; i++)
            {
                if (valorBuscar == edad[i])
                {
                    if (voto[i] == 1)
                    {
                        vacunados++;
                    }
                    else if (voto[i] == 2)
                    {
                        noVacunados++;
                    }
                    numeroEncontrado = true;
                }
            }
            if (!numeroEncontrado)
            {
                Console.WriteLine("\nEl número ingresado no existe");
            }
            else
            {
                Console.WriteLine($"\n{vacunados} se vacunaron");
                Console.WriteLine($"{noVacunados} no se vacunaron");
            }
            string texto2 = " \n" +
              "================================\n" +
              "1: Regresar\n" +
              "================================\n";
            Console.Write(texto2);

            int opcion = Operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
    }
}
