using ConsoleApp1.Interface;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Singleton
    {
        public class ClassSingleton
        {
            public static ClassSingleton instancia;
            public ClassSingleton() { }

            public List<IProcesso> Processo = new List<IProcesso>();
            public List<int> numeroProcess = new List<int>();
            public static ClassSingleton GetInstancia
            {
                get
                {
                    if (instancia == null)
                    {
                        instancia = new ClassSingleton();
                    }
                    return instancia;
                }
            }
        }
    }
}
