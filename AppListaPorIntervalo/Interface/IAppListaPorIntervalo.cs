using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.ListaPorIntervalo.Interface
{
    public interface IAppListaPorIntervalo
    {
        void ListaPorIntervalo(int intervaloMin);
        void RegistrarIntervaloFalsoPositivo(int intervaloMin);
    }
}
