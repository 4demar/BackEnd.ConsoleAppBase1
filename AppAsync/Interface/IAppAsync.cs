using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interface
{
    public interface IAppAsync
    {
        Boolean IniciarAppAsync();
        Task PassarCafe();
        void TostarPao();

    }
}
