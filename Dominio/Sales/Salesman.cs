using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Sales
{
    public class Salesman
    {
        private string Cpf { get; set; }
        private string Name { get; set; }
        private string Salary { get; set; }
        public Salesman(string cpf, string name, string salary)
        {
            Cpf = cpf;
            Name = name;
            Salary = salary;
        }
    }
}
