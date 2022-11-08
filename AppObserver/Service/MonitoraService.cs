using ConsoleApp1;
using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ConsoleApp1.Service
{
    public class MonitoraService
    {
        public void MonitorarProcesso()
        {
            ServiceGestor iniciar = new ServiceGestor();
            var singleton = Singleton.ClassSingleton.GetInstancia;
            Process[] processAberto = Process.GetProcessesByName("mspaint");
            List<int> processoAtual = new List<int>();
            for (int i = 0; i < processAberto.Length; i++)
            {
                processoAtual.Add(processAberto[i].Id);
            }

            //// Compara e mostra na tela...
            var listaCaiu = singleton.numeroProcess.Except(processoAtual).ToList();

            for (int i = 0; i < listaCaiu.Count; i++)
            {
                Console.WriteLine("Paint de PID: " + listaCaiu[i] + " fechou...");
                foreach (IProcesso dados in singleton.Processo)
                {
                    if (dados.numeroPID == listaCaiu[i])
                    {
                        Console.WriteLine("Paint: " + dados.nomeProcesso + " fechou...");
                        singleton.Processo.Remove(dados);
                        iniciar.IniciarPaint(dados.nomeProcesso);
                        break;
                    }
                }
            }
            Thread.Sleep(TimeSpan.FromSeconds(20)); // 30 Segundos
            MonitorarProcesso();
        }
    }
}
