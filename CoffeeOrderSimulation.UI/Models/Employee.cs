using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderSimulation.UI.Models
{
    public class Employee
    {
        public string Name { get; set; } // Çalışanın adı.
        public bool IsAvailable { get; private set; } = true; // Çalışanın müsaitlik durumu.
        public int OrdersProcessed { get; private set; } = 0; // Çalışanın işlem yaptığı toplam sipariş sayısı.
        public int TotalProcessingTime { get; private set; } = 0; // Çalışanın toplam sipariş hazırlama süresi.

        // Constructor: Çalışan nesnesi oluşturulurken adı set edilir.
        public Employee(string name)
        {
            Name = name;
        }

        // Siparişi işleme fonksiyonu.
        public void ProcessOrder(Order order)
        {
            IsAvailable = false; // Sipariş alındığında çalışan meşgul olarak işaretlenir.
            int processingTime = order.Product.CalculateTotalPreparationTime(); // Siparişin hazırlık süresi hesaplanır.
            TotalProcessingTime += processingTime; // Toplam hazırlık süresine eklenir.
            OrdersProcessed++; // İşlenen sipariş sayısı artırılır.

            // Kullanıcıya bilgilendirme mesajı gösterilir.
            MessageBox.Show($"{Name} is preparing {order.Product.Name} for {order.Customer.Name}. Estimated time: {processingTime} seconds with {string.Join(", ", order.Product.SideProducts)}.");

            IsAvailable = true; // İşlem tamamlandığında çalışan yeniden müsait hale gelir.
        }
    }
}
