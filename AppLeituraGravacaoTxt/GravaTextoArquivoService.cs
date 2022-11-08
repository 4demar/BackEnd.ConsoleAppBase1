using ConsoleApp1.AppDateTime.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ConsoleApp1.AppDateTime
{
    public class GravaTextoArquivoService
    {
        //private static string _file = @"C:\Users\121097\source\repos\ConsoleApp1\ConsoleApp1\AppLeituraGravacaoTxt";
        private static string _file = $"{Environment.CurrentDirectory}/AppLeituraGravacaoTxt";


        public Boolean GravaTextoArquivo()
        {
            Console.Clear();
            Console.WriteLine("Digite um texto para salvar no arquivo de Log");
            var texto = Console.ReadLine();
            var dataLog = DateTime.Now.ToLongDateString().Replace("/", "-");
            var arquivoLog = $"{_file}\\{dataLog}.txt";
            if (File.Exists(arquivoLog))
            {
                using (StreamWriter sw =File.AppendText(arquivoLog))
                {                    
                    sw.Write("\r\n {0} - {1}", DateTime.Now, texto);
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(arquivoLog))
                {
                    sw.Write("{0} - {1}",DateTime.Now, texto);
                    sw.Close();
                }
            }
            Console.WriteLine("Texto salvo!!!");
            Thread.Sleep(TimeSpan.FromSeconds(30));

            return true;
        }


    }
}
