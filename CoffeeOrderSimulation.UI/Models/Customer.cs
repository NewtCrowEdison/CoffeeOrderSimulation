using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderSimulation.UI.Models
{
    public class Customer
    {
        public string Name { get; set; } // Müşteri adı.

        // Constructor: Müşteri nesnesi oluşturulurken adı set edilir.
        public Customer(string name)
        {
            Name = name;
        }
    }
}
