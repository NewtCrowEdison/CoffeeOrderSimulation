using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderSimulation.UI.Models
{
    public class Product
    {
        public string Name { get; set; } // Ürünün adı.
        public int PreparationTime { get; set; } // Ürünün hazırlanma süresi (saniye cinsinden).
        public List<string> SideProducts { get; set; } = new List<string>(); // Ürünle birlikte eklenen yan ürünler.

        // Constructor: Ürünün adı ve hazırlanma süresi set edilir.
        public Product(string name, int preparationTime)
        {
            Name = name;
            PreparationTime = preparationTime;
        }

        // Toplam hazırlık süresini hesaplayan fonksiyon.
        public int CalculateTotalPreparationTime()
        {
            int extraTime = 0; // Yan ürünlerin ek süreleri.
            foreach (var side in SideProducts)
            {
                extraTime += 2; // Her yan ürün için varsayılan ek süre 2 saniye.
            }
            return PreparationTime + extraTime; // Ana hazırlık süresi ve yan ürün süreleri toplanır.
        }
    }
}
