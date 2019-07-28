using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Sales
{
    public class Sales
    {
        public int Id { get; set; }
        public List<Item> Itens { get; set; }
        public string SalesmanName { get; set; }
        public decimal TotalValueSale { get { return Itens.Sum(x => x.TotalValue); } }
        public Sales(object id, object itens, string salesmanName)
        {
            Id = Convert.ToInt32(id);
            Itens = (List<Item>)itens;
            SalesmanName = salesmanName;
        }
    }
}
