using ConsoleApp1.Interface;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Service
{
    public class AppAsync : IAppAsync
    {
        public Boolean IniciarAppAsync()
        {
            Task taskPassarcafe = PassarCafe();
            TostarPao();
            taskPassarcafe.Wait();
            Console.WriteLine("Cafe da Manhã esta na Mesa !");
            return true;

        }

        public async Task PassarCafe()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Passando café.. {i}");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Cafe Pronto!");
            });
        }

        public void TostarPao()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Tostando pão.. {i}");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Pao Pronto!");
        }

    }
    
}