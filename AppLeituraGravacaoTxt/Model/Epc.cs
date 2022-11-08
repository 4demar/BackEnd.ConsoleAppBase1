using System;

namespace ConsoleApp1.AppDateTime.Model
{
    public class Epc
    {
        public string _id { get; set; }
        public string Hex { get; set; }
        public string Barcode { get; set; }
        public string Tid { get; set; }
        public string NomeReader { get; set; }
        public DateTime Data { get; set; }
        public string IdReader { get; set; }
        /// <summary>
        /// Utilizado para fazer a validação na detecção em tempo real
        /// </summary>
    }
}
