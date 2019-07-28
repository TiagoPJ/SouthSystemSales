using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Sales
{
    public class Item
    {
        private int Id { get; set; }
        private int Quantity { get; set; }
        private decimal Price { get; set; }
        public decimal TotalValue { get { return Quantity * Price; } }
        public Item(object id, object quantity, object price)
        {
            Id = Convert.ToInt32(id);
            Quantity = Convert.ToInt32(quantity);
            Price = Convert.ToDecimal(price);
        }
    }
}
