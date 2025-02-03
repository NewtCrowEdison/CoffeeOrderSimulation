using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderSimulation.UI.Models
{
    public class Order
    {
        public Customer Customer { get; set; } // Siparişi veren müşteri.
        public Product Product { get; set; } // Sipariş edilen ürün.

        // Constructor: Sipariş oluşturulurken müşteri ve ürün set edilir.
        public Order(Customer customer, Product product)
        {
            Customer = customer;
            Product = product;
        }
    }
}
