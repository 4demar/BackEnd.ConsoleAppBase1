using ConsoleApp1;
using ConsoleApp1.Interface;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Service
{
    public class ServiceGestor
    {

        /// <summary>  metodo de abrir obsserver </summary>
        /// <param name="nome">digite o nome</param>
        /// <param name="numero">digite o numero</param>
        public void IniciarAppObserver()
        {
            var monitor = ConcreteSubject.GetInstancia;

            FecharProcessos();
            for (int i = 0; i <= 2; i++)
            {
                IniciarProcesso(i, monitor);
            }

            Thread.Sleep(TimeSpan.FromSeconds(5)); // 30 Segundos

            //monitorar.MonitorarProcesso(); //sem observer
            monitor.MonitorWorkers(monitor); //Com observer
        }

        /// <summary> metodo de iniciar Paint  </summary>
        /// <param name="numero">digite o numero</param>
        public void IniciarPaint(int numero)
        {
            var singleton = Singleton.ClassSingleton.GetInstancia;
            Process inicioWorker = new Process();

            inicioWorker.StartInfo.CreateNoWindow = false;
            inicioWorker.StartInfo.UseShellExecute = true;
            inicioWorker.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            inicioWorker.StartInfo.WorkingDirectory = "%windir%\\system32";
            inicioWorker.StartInfo.FileName = "mspaint.exe";

            //inicioWorker.StartInfo.Arguments = numeroworker.ToString();

            try
            {
                inicioWorker.Start();
                singleton.numeroProcess.Add(inicioWorker.Id);
                singleton.Processo.Add(new IProcesso() { numeroPID = inicioWorker.Id, nomeProcesso = numero });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        /// <summary>  metodo de abrir obsserver </summary>
        /// <param name="nome">digite o nome</param>
        /// <param name="numero">digite o numero</param>
        public void FecharProcessos()
        {
            Process[] processAberto = Process.GetProcessesByName("mspaint");
            for (int i = 0; i < processAberto.Length; i++)
            {
                processAberto[i].Kill();
            }

        }


        /// <summary> Aqui se inicia um processo </summary>
        /// <param name="numero">Numero do processo</param>
        /// <param name="gestorWorker">Numero do gestor</param>
        public void IniciarProcesso(int numero, ISubject gestorWorker)
        {
            //var singleton = Singleton.ClassSingleton.GetInstancia;
            Process inicioWorker = new Process();

            inicioWorker.StartInfo.CreateNoWindow = false;
            inicioWorker.StartInfo.UseShellExecute = true;
            inicioWorker.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            inicioWorker.StartInfo.WorkingDirectory = "%windir%\\system32";
            inicioWorker.StartInfo.FileName = "mspaint.exe";

            //inicioWorker.StartInfo.Arguments = numeroworker.ToString();

            try
            {
                inicioWorker.Start();
                var processo = new IProcesso() { numeroPID = inicioWorker.Id, nomeProcesso = numero };
                ConcreteObserver consoleWorker = new ConcreteObserver(numero, processo, gestorWorker);
                //singleton.numeroProcess.Add(inicioWorker.Id);
                //singleton.Processo.Add(new IProcesso() { numeroPID = inicioWorker.Id, nomeProcesso = numero });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void PrintarTela(Task task)
        {
            Console.WriteLine(task);
        }

        public void PrintarNumeroTela(int numero)
        {
            Console.WriteLine(numero + " Esse foi o numero Impresso...");
        }
    }
    
}