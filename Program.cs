using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Practica_Nro._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Salir = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Buenas, Eliga los ejercicios :P :");
                Console.WriteLine("");
                Console.WriteLine("1. Primeros ejercicios");
                Console.WriteLine("2. Segundos ejercicios");
                Console.WriteLine("");
                Console.WriteLine("0. Salir");
                byte opcMain = Convert.ToByte(Console.ReadLine());

                switch (opcMain)
                {
                    case 0:
                        Salir = true;
                        break;
                    case 1:
                        Console.Clear();

                        Console.WriteLine("Que inciso del ejercico");
                        Console.WriteLine("");
                        Console.WriteLine("a. Calcular factorial");
                        Console.WriteLine("b. Crear tabla de un numero");
                        Console.WriteLine("c. Imprimir serie de Fibonacci");
                        Console.WriteLine("");
                        Console.WriteLine("s. Salir");
                        string opc = Console.ReadLine();

                        switch (opc)
                        {
                            case "s":
                                Console.Clear();
                                Salir = true;
                                break;
                            case "a":
                                Factorial();
                                break;
                            case "b":
                                Tabla();
                                break;
                            case "c":
                                Fibonacci();
                                break;
                            default:
                                MensajeError("Opcion Invalida, Eliga otra");
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();

                        Console.WriteLine("Que inciso del ejercico");
                        Console.WriteLine("");
                        Console.WriteLine("a. Calcular area de figuras");
                        Console.WriteLine("b. Conversion de unidades");
                        Console.WriteLine("c. Ordenar numeros o palabras");
                        Console.WriteLine("d. Cambiar formato de fechas");
                        Console.WriteLine("");
                        Console.WriteLine("s. Salir");
                        string opcSec = Console.ReadLine();

                        switch (opcSec)
                        {
                            case "s":
                                Salir = true;
                                break;
                            case "a":
                                CalculoArea();
                                break;
                            case "b":
                                ConversionMedidas();
                                break;
                            case "c":
                                Ordenar();
                                break;
                            case "d":
                                CambiarFormato();
                                break;
                            default:
                                MensajeError("Opcion Invalida, Eliga otra");
                                break;
                        }
                        break;
                    default:
                        MensajeError("Opcion Invalida, Eliga otra");
                        break;
                }
            } while (!Salir);
        }
        // primeros ejercicios mediante recursividad

        static void Factorial()
        {
            Console.Clear();

            Console.WriteLine("Ingrese el numero que quieres calcular su factorial");
            int numero = Convert.ToInt32(Console.ReadLine());
            int numFact = FactorialFormula(numero);

            Console.WriteLine($"EL factorial de {numero} es : {numFact}");
            Console.ReadKey();

        }
        static int FactorialFormula(int numero)
        {
            if (numero == 1)
            {
                return numero;
            }
            else
            {
                return numero * FactorialFormula(numero - 1);
            }
        }
        static void Tabla()
        {
            Console.Clear();

            Console.WriteLine("Ingrese el numero que quieres calcular su tabla de multiplicar");
            int numero = Convert.ToInt32(Console.ReadLine());
            int n = 1;

            Console.WriteLine($"Tabla del {numero}");

            TablaImprimir(numero, n);
            Console.ReadKey();

        }
        static void TablaImprimir(int numero, int n)
        {
            if (n > 10)
                return;
            Console.WriteLine($"{numero} x {n} = {numero * n}");

            TablaImprimir(numero, n + 1);
        }
        static void Fibonacci()
        {
            Console.Clear();

            Console.WriteLine("¿Cuántos términos de la serie de Fibonacci deseas mostrar? ");
            int Cant = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Serie de Fibonacci:");
            for (int i = 0; i < Cant; i++)
            {
                Console.Write(FibonacciFormula(i) + " ");
            }
            Console.ReadKey();

        }
        static int FibonacciFormula(int n)
        {
            if (n <= 1)
                return n;
            else // formula de Fibonacci F(n) = F(n−1) + F(n−2)
                return FibonacciFormula(n - 1) + FibonacciFormula(n - 2);
        }

        // segundos ejercicios usando sobrecarga

        static void CalculoArea()
        {
            Console.Clear();
            Console.WriteLine("Seleccione la figuja de la que desea calcular el area");
            Console.WriteLine("1. Circulo");
            Console.WriteLine("2. Cuadrado");
            Console.WriteLine("3. Rectangulo");

            byte figura = Convert.ToByte(Console.ReadLine());

            switch (figura)
            {
                case 1:
                    Console.WriteLine("Digite el radio del circulo");
                    CalcularArea(Convert.ToDouble(Console.ReadLine()));
                    break;
                case 2:
                    Console.WriteLine("Digite el tamaño de los lados");
                    double lado = Convert.ToDouble(Console.ReadLine());
                    CalcularArea(lado, true);
                    break;
                case 3:
                    Console.WriteLine("Digite el ancho");
                    double ancho = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Digite el largo");
                    double largo = Convert.ToDouble(Console.ReadLine());
                    CalcularArea(largo, ancho);

                    break;
                default:
                    MensajeError("No hay figura correspondiente al inciso");
                    break;
            }
        }
        static void CalcularArea(double radio)
        {
            Console.WriteLine($" EL area del circulo es de {Math.PI * radio * radio}");
            Console.ReadLine();
        }
        static void CalcularArea(double lado, bool esCuadrado)
        {
            Console.WriteLine($" EL area del cuadrado es de {lado * lado}");
            Console.ReadLine();

        }
        static void CalcularArea(double largo, double ancho)
        {
            Console.WriteLine($" EL area del circulo es de {largo * ancho}");
            Console.ReadLine();

        }

        static void ConversionMedidas()
        {
            Console.Clear();

            Console.WriteLine("Digite la cantidad de unidades");
            int unidades = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite la medida base");
            string medidaBase = Console.ReadLine();
            Console.WriteLine("Digite la medida nueva");
            string medidaNueva = Console.ReadLine();

            double resultado = Convert.ToDouble(ConversionProceso(unidades, medidaBase, medidaNueva));

            Console.WriteLine($"{unidades} {medidaBase} en {medidaNueva} son {resultado} {medidaNueva}");
            Console.ReadKey();
        }
        static double ConversionProceso(int cant, string medidaBase, string medidaNueva)
        {
            if (medidaBase == "cm" && medidaNueva    == "m")
                return cant / 100;
            if (medidaBase == "m" && medidaNueva == "km")
                return cant / 1000;
            if (medidaBase   == "km" && medidaNueva == "m")
                return cant * 1000;
            if (medidaBase == "m" && medidaNueva == "cm")
                return cant * 100;

            Console.WriteLine("Medida incorrecta o desconocida, pruebe con: cm, m o km");
            return cant;
        }

        static void Ordenar()
        {
            Console.WriteLine("No termine x_x quedo a medias");
            Console.ReadKey();


            /* byte i = 0;
             Console.WriteLine("Es un arreglo de: ");
             Console.WriteLine("1. palabras");
             Console.WriteLine("2. numeros");
             Console.WriteLine("(limite 5 elemtentos)");
             byte arregloTipo = Convert.ToByte(Console.ReadLine());

             if (arregloTipo == 1)
             {
                 List<string> lista = new List<string>(5);

                 while (i<5)
                 {
                     Console.WriteLine("Digite el elemento");
                     lista.Add(Console.ReadLine());
                     i ++;

                     OrdenarLista(lista);
                 }
             }
             else if (arregloTipo == 2)
             {
                 List<int> lista = new List<int>(5);
                 while (i < 5)
                 {
                     Console.WriteLine("Digite el elemento");
                     lista.Add(Convert.ToInt32(Console.ReadLine()));
                     i++;
                     OrdenarLista(lista);

                 }
             }*/
        }
        static void OrdenarLista(int lista)
         {

         }

        static void CambiarFormato()
        {
            Console.Clear();

            bool salir = false;

            Console.WriteLine("Ingrese el dia");
            byte dd = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Ingrese el mes");
            byte mm = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Ingrese el año");
            int aaaa = Convert.ToInt32(Console.ReadLine());

            while (!salir)
            {
                Console.WriteLine("Elija el formato: 1. dd/mm/aaaa 2. mm/dd/aaaa");
                Console.WriteLine("0. salir");

                byte formato = Convert.ToByte(Console.ReadLine());
                if (formato == 0)
                {
                    salir = true;
                }
                 if(formato == 1)
                {
                    FormatoNuevo(dd, mm, aaaa);
                }
                 if (formato == 2)
                {
                    FormatoNuevo(aaaa, mm, dd);
                }
            }
        } 
        static void FormatoNuevo(byte dd, byte mm, int aaaa)
        {
            Console.WriteLine($"Nuevo formato : {dd}/{mm}/{aaaa}");
            Console.ReadKey();
        }
        static void FormatoNuevo(int aaaa, byte mm, byte dd)
        {
            Console.WriteLine($"Nuevo formato : {mm}/{dd}/{aaaa}");
            Console.ReadKey();
        }

        // general

        static void MensajeError(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
            Console.ReadKey();
        }
    }
}