using System;
using System.Collections.Generic;
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
                Console.WriteLine("Buenas, cuales ejercicos quiere ver :P :");
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
        // primeros ejercicios

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

        // segundos ejercicios

        static void CalculoArea()
        {
            Console.WriteLine("Seleccione la figuja de la que desea calcular el area");
            Console.WriteLine("1. Circulo");
            Console.WriteLine("2. Cuadrado");
            Console.WriteLine("2. Rectangulo");

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
        }
        static void CalcularArea(double lado, bool esCuadrado)
        {
            Console.WriteLine($" EL area del cuadrado es de {lado * lado}");
        }
        static void CalcularArea(double largo, double ancho)
        {
            Console.WriteLine($" EL area del circulo es de {largo * ancho}");
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
        
        }

        static void CambiarFormato()
        {
            Console.WriteLine("Ingrese el dia");
            string dd = Console.ReadLine();
            Console.WriteLine("Ingrese el mes");
            string mm = Console.ReadLine();
            Console.WriteLine("Ingrese el año");
            string aaaa = Console.ReadLine();

            FormatoNuevo(dd, mm, aaaa);
        } 
        static void FormatoNuevo(string dd, string mm, string aaaa)
        {
            Console.WriteLine($"Nuevo formato : {dd}/{mm}/{aaaa}");
        }
        static void FormatoNuevo(string aaaa, string mm, string dd)
        {
            Console.WriteLine($"Nuevo formato : {mm}/{dd}/{aaaa}");

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