using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1.Service
{
    public class AppLinqConsultas : IAppLinqConsultas
    {
        public class Cliente
        {
            public int Key;
            public string Nome;
        }

        public class Pedido
        {
            public int Key;
            public string NumeroPedido;
        }

        public Boolean Iniciar_LinqConsultas()
        {
            Console.Clear();
            Console.WriteLine("Vamos Brincar...");
            Console.WriteLine("\nInforme um numero para consulta Linq");
            var numeroLinq = Console.ReadLine();

            switch (numeroLinq)
            {
                case "1":
                    consulta1();
                    break;
                case "2":
                    consulta2();
                    break;
                case "3":
                    consulta3();
                    break;
                case "4":
                    consulta4();
                    break;
                case "5":
                    consulta5();
                    break;
                case "6":
                    consulta6();
                    break;
                case "7":
                    consulta7();
                    break;
                case "8":
                    consulta8();
                    break;
                case "9":
                    consulta9();
                    break;
                case "10":
                    consulta10();
                    break;
                case "11":
                    consulta11();
                    break;
                case "12":
                    consulta12();
                    break;
            }
            Thread.Sleep(TimeSpan.FromSeconds(20));
            return true;
        }

        private static void consulta1()
        {
            string[] times = { "Palmeiras", "Santos", "Botafogo", "Vasco" };
            //IEnumerable<string> timesFiltrados = Enumerable.Where( times, n => n.Length >= 6);
            IEnumerable<string> timesFiltrados = times.Where(n => n.Length >= 6);

            foreach (string n in timesFiltrados)
                Console.Write(n + "|");
        }
        private static void consulta2()
        {
            string[] times = { "Palmeiras", "Santos", "Botafogo", "Vasco" };

            IEnumerable<string> consulta = times
                                .Where(n => n.Contains("s"))
                                .OrderBy(n => n.Length)
                                .Select(n => n.ToUpper());

            foreach (string n in consulta)
                Console.Write(n + " | ");
        }
        private static void consulta3()
        {
            string[] times = { "Palmeiras", "Santos", "Botafogo", "Vasco" };

            IEnumerable<int> consulta = times.Select(n => n.Length);

            foreach (int n in consulta)
                Console.Write(n);
        }
        private static void consulta4()
        {
            int[] numeros = { 10, 9, 8, 7, 6 };
            int primeiro = numeros.First();
            int ultimo = numeros.Last();
            int segundo = numeros.ElementAt(1);
            int contador = numeros.Count();
            int minimo = numeros.Min();
            int maximo = numeros.Max();
            int soma = numeros.Sum();

            Console.WriteLine(primeiro);//10
            Console.WriteLine(ultimo);//6
            Console.WriteLine(segundo);//9
            //
            Console.WriteLine("Total de elementos : " + contador);
            Console.WriteLine("Elemento mínimo    : " + minimo);
            Console.WriteLine("Elemento mãximo    : " + maximo);
            Console.WriteLine("Soma dos elementos : " + soma);
        }
        private static void consulta5()
        {
            int[] numeros = { 10, 9, 8, 7, 6 };
            bool temONumeroNove = numeros.Contains(9); // true
            bool temMaisqueZeroElementos = numeros.Any(); // true
            bool temUmLementoImpart = numeros.Any(n => n % 2 == 1); // true
            //
            Console.WriteLine("Possui o elemento 9 ? : " + temONumeroNove);
            Console.WriteLine("Possui mais que Zero elementos ? " + temMaisqueZeroElementos);
            Console.WriteLine("Possui um elemento impar ? " + temUmLementoImpart);
        }
        private static void consulta6()
        {
            int[] numeros = { 10, 9, 8, 7, 6, 2, 4 };

            var primeiros_Tres_Numeros = numeros.Take(3);

            Console.WriteLine("Os 3 primeiros números da sequência são { 10, 9, 8, 7, 6 , 2, 4} :");

            foreach (var n in primeiros_Tres_Numeros)
            { Console.WriteLine(n); }
        }
        private static void consulta7()
        {
            int[] numeros = { 10, 9, 8, 7, 6 };

            var Todos_Numeros_Exceto_Os_3_Primeiros = numeros.Skip(3);

            Console.WriteLine("Listando todos, exceto os 3 primeiros \nnúmeros da sequência são { 10, 9, 8, 7, 6 } :");

            foreach (var n in Todos_Numeros_Exceto_Os_3_Primeiros)
            { Console.WriteLine(n); }
        }
        private static void consulta8()
        {
            int[] numeros = { 10, 9, 8, 7, 6 };
        }
        private static void consulta9()
        {
            int[] numerosA = { 0, 2, 4, };
            int[] numerosB = { 1, 3, 5, };
            var todosNumeros = numerosA.Concat(numerosB);
            Console.WriteLine("Todos os numeros de ambos os arrays:");
            foreach (var n in todosNumeros)
            { Console.WriteLine(n); }
        }
        private static void consulta10()
        {

            int[] numerosA = { 0, 2, 3 };
            int[] numerosB = { 1, 3, 5 };

            var todosNumerosExcetoDuplicados = numerosA.Union(numerosB);

            Console.WriteLine("Todos os numeros de ambos os arrays \nExceto os duplicados:");

            foreach (var n in todosNumerosExcetoDuplicados)
            { Console.WriteLine(n); }
        }
        private static void consulta11()
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6 };
            var numerosOrdemReversa = numeros.Reverse();

            foreach (var n in numerosOrdemReversa)
            { Console.WriteLine(n); }
        }
        private static void consulta12() //ExempleJoin
        {
            var clientes = new List<Cliente>() {
                new Cliente {Key = 1, Nome = "Macoratti" },
                new Cliente {Key = 2, Nome = "Miriam" },
                new Cliente {Key = 5, Nome = "Janice" }
            };

            var pedidos = new List<Pedido>() {
                new Pedido {Key = 1, NumeroPedido = "Pedido 1" },
                new Pedido {Key = 1, NumeroPedido = "Pedido 2" },
                new Pedido {Key = 4, NumeroPedido = "Pedido 3" },
                new Pedido {Key = 5, NumeroPedido = "Pedido 5" },
            };

            var q = from c in clientes
                    join o in pedidos on c.Key equals o.Key
                    select new { c.Nome, o.NumeroPedido };

            foreach (var i in q)
            {
                Console.WriteLine("Cliente : {0}  Pedido Numero: {1}", i.Nome.PadRight(11, ' '), i.NumeroPedido);
            }
        }

    }
}
