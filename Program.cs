using System;

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
                Console.WriteLine("Buenas, elige un ejercicio :P");
                Console.WriteLine("\nPrimeros ejercios\n");
                Console.WriteLine("1. Calcular factorial");
                Console.WriteLine("2. Crear tabla de un número");
                Console.WriteLine("3. Imprimir serie de Fibonacci");
                Console.WriteLine("\nSegundos ejercios\n");
                Console.WriteLine("4. Calcular área de figuras");
                Console.WriteLine("5. Conversión de unidades");
                Console.WriteLine("6. Ordenar números o palabras");
                Console.WriteLine("7. Cambiar formato de fechas");
                Console.WriteLine("\n0. Salir");

                byte opcion = Convert.ToByte(Console.ReadLine());

                switch (opcion)
                {
                    case 0:
                        Salir = true;
                        break;
                    case 1:
                        Factorial();
                        break;
                    case 2:
                        Tabla();
                        break;
                    case 3:
                        Fibonacci();
                        break;
                    case 4:
                        CalculoArea();
                        break;
                    case 5:
                        ConversionMedidas();
                        break;
                    case 6:
                        Ordenar();
                        break;
                    case 7:
                        CambiarFormato();
                        break;
                    default:
                        MensajeError("Opción inválida, elige otra.");
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
            if (numero == 1) return numero;
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
            string[] boxString = new string[5];
            int[] boxInt = new int[5];
            bool esNumero = true;

            Console.WriteLine("Ingrese los elementos (máximo 5), deben ser solo números o solo letras:");
            
            string primerElemento = Console.ReadLine(); // Pedimos el primer elemento y verificamos si es un número o un string

            if (int.TryParse(primerElemento, out int resultado))
            {
                boxInt[0] = resultado;
            }
            else
            {
                boxString[0] = primerElemento;
                esNumero = false;
            }
           
            for (int i = 1; i < 5; i++) // Seguimos ingresando los otros 4 elementos
            {
                Console.WriteLine($"Ingrese el elemento {i + 1}:");
                string input = Console.ReadLine();

                if (esNumero==true)
                {
                    // Si el primer elemento fue un número, esperamos solo números
                    if (int.TryParse(input, out int numero))
                    {
                        boxInt[i] = numero;
                    }
                    else
                    {
                        Console.WriteLine("Error: Todos los elementos deben ser números.");
                        return;
                    }
                }
                else
                {
                    // Si el primer elemento fue un string, esperamos solo strings
                    boxString[i] = input;
                }
            }

            // Llamamos a la función adecuada para ordenar y mostrar los elementos
            if (esNumero==true)
            {
                OrdenarLista(boxInt);
            }
            else
            {
                OrdenarLista(boxString);
            }
        }
        static void OrdenarLista(string[] box)
        {
            Array.Sort(box);
            MostrarArrayOrdenado(box);
        }
        static void OrdenarLista(int[] box)
        {
            Array.Sort(box);
            MostrarArrayOrdenado(box);
        }
        static void MostrarArrayOrdenado<T>(T[] box)
        {
            Console.WriteLine("Elementos ordenados:");
            foreach (var elemento in box)
            {
                Console.Write($"{elemento}, ");
            }
            Console.ReadKey();
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
                if (formato == 0) salir = true;
                 if(formato == 1) FormatoNuevo(dd, mm, aaaa);
                 if (formato == 2) FormatoNuevo(aaaa, mm, dd);
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
            Console.WriteLine("\n"+msg);
            Console.ReadKey();
        }
    }
}