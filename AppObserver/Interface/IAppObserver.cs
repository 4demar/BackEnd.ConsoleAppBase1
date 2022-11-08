using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interface
{
    public interface IAppObserver
    {
        void IniciarAppObserver();
        void IniciarPaint(int numero);
        void IniciarProcesso(int numero, ISubject gestorWorker);
        void PrintarTela(Task task);
        void PrintarNumeroTela(int numero);


    }
}
