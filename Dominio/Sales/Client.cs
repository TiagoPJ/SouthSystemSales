using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Sales
{
    public class Client
    {
        private string Cnpj { get; set; }
        private string Name { get; set; }
        private string Business { get; set; }
        public Client(string cnpj, string name, string business)
        {
            Cnpj = cnpj;
            Name = name;
            Business = business;
        }
    }
}
