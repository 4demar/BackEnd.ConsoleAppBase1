using ConsoleApp1.ListaPorIntervalo.Model;
using ConsoleApp1.ListaPorIntervalo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.ListaPorIntervalo.Service
{
    public class AppListaPorIntervalo : IAppListaPorIntervalo
    {

        private List<ItemEpc> listaEpcs = new List<ItemEpc>
        {
            new ItemEpc { Barcode = "302EF13CBE400BC000002B2B", Data = DateTime.Parse("10/10/2018 00:01:00"), ItemComAlerta = false }, //list0 true
            new ItemEpc { Barcode = "302EF13CBE400BC000002B2B", Data = DateTime.Parse("10/10/2018 00:02:01"), ItemComAlerta = false }, //list0 true
            new ItemEpc { Barcode = "302EF13CBE400BC000002B2B", Data = DateTime.Parse("10/10/2018 00:03:04"), ItemComAlerta = false }, //list0 true
            new ItemEpc { Barcode = "302EF13CBE400BC000005B9E", Data = DateTime.Parse("10/10/2018 00:17:09"), ItemComAlerta = false }, //list2          false
            new ItemEpc { Barcode = "302EF13CBE400BC000002B2B", Data = DateTime.Parse("10/10/2018 00:25:10"), ItemComAlerta = false }, //list0; false.......

            new ItemEpc { Barcode = "302EF13CBE400BC000002B2B", Data = DateTime.Parse("10/10/2018 07:45:00")}, //list4 true
            new ItemEpc { Barcode = "302EF13CBE400BC000005B9E", Data = DateTime.Parse("10/10/2018 07:45:01")}, //               false
            new ItemEpc { Barcode = "302EF13CBE400BC000002B2B", Data = DateTime.Parse("10/10/2018 07:49:00")}, //list4 true
            new ItemEpc { Barcode = "303B6EE840DB0AC00000033E", Data = DateTime.Parse("10/10/2018 08:45:02")},
            new ItemEpc { Barcode = "302EF13CBE400BC000002B2B", Data = DateTime.Parse("10/10/2018 08:45:04")},
            new ItemEpc { Barcode = "302EF13CBE400BC000005B9E", Data = DateTime.Parse("10/10/2018 09:46:30")},
            new ItemEpc { Barcode = "302EF13CBE400BC000002B2B", Data = DateTime.Parse("10/10/2018 09:49:00")},

            //new ItemEpc { Barcode = "303B6EE840DB0AC00000033E", Data = DateTime.Parse("10/10/2018 11:07:40")}, //list5
            //new ItemEpc { Barcode = "302EF13CBE400BC000002B2B", Data = DateTime.Parse("10/10/2018 11:25:00")},
            //new ItemEpc { Barcode = "302EF13CBE400BC000005B9E", Data = DateTime.Parse("10/10/2018 11:30:00")},
            //new ItemEpc { Barcode = "303B6EE840DB0AC00000033E", Data = DateTime.Parse("10/10/2018 11:30:03")}, //list5
            //new ItemEpc { Barcode = "302EF13CBE400BC000002B2B", Data = DateTime.Parse("10/10/2018 11:30:07")},
            //new ItemEpc { Barcode = "303B6EE840DB0AC00000033E", Data = DateTime.Parse("10/10/2018 11:33:02")}, //list5
            //new ItemEpc { Barcode = "303B6EE840DB0AC00000033E", Data = DateTime.Parse("10/10/2018 11:34:10")}, //list5           
        };

        private Dictionary<int, List<ItemEpc>> ListaPassagemVendaLeitura(int intervaloPassagem)
        {
            var passagemEpc = new Dictionary<int, List<ItemEpc>>();

            listaEpcs = listaEpcs.OrderByDescending(x => x.Data).ToList();

            int contadorControladora = 0;

            if (listaEpcs.Count > 0)
            {
                passagemEpc.Add(0, new List<ItemEpc> { listaEpcs[0] });//Adiciona na lista de agrupamento de passagens, o primeiro valor da listaEpcs(Dia anterior)
            }
            do
            {
                for (int contadorEpc = 0; contadorEpc < listaEpcs.Count; contadorEpc++)
                {
                    if (listaEpcs.Count > contadorEpc + 1)
                    {
                        var valorAnterior = passagemEpc.ContainsKey(passagemEpc.Keys.Last());
                        var dataRegistroMenor = (listaEpcs[contadorEpc + 1].Data - listaEpcs[contadorEpc].Data).Duration() <= new TimeSpan(0, 0, intervaloPassagem);

                        if (valorAnterior && dataRegistroMenor)
                            passagemEpc[passagemEpc.Keys.Last()].Add(listaEpcs[contadorEpc + 1]);

                        else
                        {
                            passagemEpc.Add(passagemEpc.Keys.Last() + 1, new List<ItemEpc> { listaEpcs[contadorEpc + 1] });
                        }
                    }
                    contadorControladora++;
                }

            } while (listaEpcs.Count > contadorControladora + 1);
            return passagemEpc;
        }

        public void ListaPorIntervalo(int intervaloMin)
        {
            var passagemEpc = ListaPassagemVendaLeitura(intervaloMin);

            foreach (var values in passagemEpc)
            {
                for (int x = 0; x < values.Value.Count() ; x++)
                {
                    var dataInicial = values.Value[0].Data;
                    var dataFinal = values.Value[^1].Data;
                    var value = values.Value[x];
                    Console.WriteLine("\nPassagem:{0};{1};{2};{3};{4};{5};{6};{7}", 
                        values.Key, 
                        value.IdReader,
                        dataInicial,
                        dataFinal,
                        value.Data, 
                        value.Barcode, 
                        value.Hex, 
                        value.ItemComAlerta
                    );
                }
            }
        }


        public void RegistrarIntervaloFalsoPositivo(int intervaloMin)
        {
            var intervalo = TimeSpan.FromMinutes(intervaloMin);
            var listCount = new List<ItemEpc>();

            //var filtro = listaEpcs.GroupBy(x => x.Barcode).ToList();

            for (int i = 0; i < listaEpcs.Count; i++)
            {
                for (int j = i + 1; j < listaEpcs.Count; j++)
                {
                    if (((listaEpcs[i].Data - listaEpcs[j].Data).Duration() <= intervalo) && (listaEpcs[i].Barcode == listaEpcs[j].Barcode))
                    {
                        listCount.Add(listaEpcs[j]);
                        if (!listCount.Contains(listaEpcs[i]))
                        {
                            listCount.Add(listaEpcs[i]);
                        };
                    }
                }
                if (listCount.Count >= 3) //Quantidade de Itens por intervalo
                {
                    listCount.ForEach(x => x.ItemComAlerta = true);
                }
                listCount.Clear();
            }

            var values = listaEpcs;

            for (int x = 0; x < values.Count; x++)
            {
                var value = values[x];
                Console.WriteLine("\n{0};{1};{2};{3};{4}", value.IdReader, value.Data, value.Barcode, value.Hex, value.ItemComAlerta);
            }

        }
    }
}