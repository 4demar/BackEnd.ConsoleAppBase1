using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp1.Service
{
    public class ConcreteObserver : IObserver
    {
        public int NumeroApp { get; set; }
        public IProcesso ProcessoApp { get; set; }

        public ConcreteObserver(int numeroApp, IProcesso processoApp, ISubject subject)
        {
            NumeroApp = numeroApp;
            ProcessoApp = processoApp;
            subject.AdicionarObservers(this);
        }

        public int getNumeroApp()
        {
            return NumeroApp;
        }
        public int getListaPID()
        {
            return ProcessoApp.numeroPID;
        }

        public IProcesso getListaProcesso()
        {
            return ProcessoApp;
        }       
        
    }
}
