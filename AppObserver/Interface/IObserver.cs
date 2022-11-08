using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Interface
{
    public interface IObserver
    {
        int getNumeroApp();
        int getListaPID();
        IProcesso getListaProcesso();

    }
}
