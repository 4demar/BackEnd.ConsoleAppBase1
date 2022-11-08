using ConsoleApp1.AppDateTime;
using ConsoleApp1.ListaPorIntervalo.Service;
using ConsoleApp1.Service;
using System;
using System.Threading;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            var appGravaTextoArquivo = new GravaTextoArquivoService();
            var appObserver = new ServiceGestor();
            var appAsync = new AppAsync();
            var appListaIntervalo = new AppListaPorIntervalo();
            var appLinqConsultas = new AppLinqConsultas();

            var retorno = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Fala dev..");
                Console.WriteLine("Qual aplicação deseja iniciar?");
                Console.WriteLine("1 - Observer");
                Console.WriteLine("2 - Async");
                Console.WriteLine("3 - Grava Texto Arquivo");
                Console.WriteLine("4 - Lista Por Intervalo");
                Console.WriteLine("5 - RegistrarIntervaloFalsoPositivo");
                Console.WriteLine("6 - LINQ Consultas em List ou Array");

                var numeroApp = Console.ReadLine();

                if (numeroApp == "1")
                    appObserver.IniciarAppObserver();
                else if (numeroApp == "2")
                    retorno = appAsync.IniciarAppAsync();
                else if (numeroApp == "3")
                    retorno = appGravaTextoArquivo.GravaTextoArquivo();
                else if (numeroApp == "4")
                    appListaIntervalo.ListaPorIntervalo(5);
                else if (numeroApp == "5")
                    appListaIntervalo.RegistrarIntervaloFalsoPositivo(5);
                else if (numeroApp == "6")
                    retorno = appLinqConsultas.Iniciar_LinqConsultas();

            }
            while (retorno);

        }
    }
}
