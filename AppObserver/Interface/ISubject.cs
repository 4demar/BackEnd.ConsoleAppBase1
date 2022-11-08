using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interface
{
    public interface ISubject
    {
        void AdicionarObservers(IObserver observer);

        void RemoveObserver(int numero);

        void MonitorWorkers(ISubject dateObservers);
    }
}
