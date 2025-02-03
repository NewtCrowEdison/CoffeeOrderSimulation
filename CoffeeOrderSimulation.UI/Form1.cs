using CoffeeOrderSimulation.UI.Models;

namespace CoffeeOrderSimulation.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeData(); // Form yüklenirken gerekli veri yapýlarýn ve çalýþanlarýn baþlatýlmasý.
        }

        private List<Employee> employees = new List<Employee>(); // Çalýþan nesnelerini tutacak liste.
        private Queue<Order> orderQueue = new Queue<Order>(); // Sipariþleri tutan bir kuyruk.
        private List<Product> products = new List<Product>(); // Kahve ürünlerini tutan liste.

        private void InitializeData()
        {
            // Kahve ürünlerini listeye ekliyoruz.
            products.Add(new Product("Espresso", 5));
            products.Add(new Product("Latte", 7));
            products.Add(new Product("Cappuccino", 6));
            products.Add(new Product("Flat White", 8));
            products.Add(new Product("Mocha", 10));
            products.Add(new Product("Americano", 4));
            products.Add(new Product("Macchiato", 5));
            products.Add(new Product("Turkish Coffee", 6));
            products.Add(new Product("Cortado", 5));
            products.Add(new Product("Affogato", 8));
            products.Add(new Product("Cold Brew", 9));
            products.Add(new Product("Iced Latte", 10));
            products.Add(new Product("Frappuccino", 12));
            products.Add(new Product("Caramel Macchiato", 9));
            products.Add(new Product("Vanilla Latte", 8));
            products.Add(new Product("Hazelnut Cappuccino", 9));
            products.Add(new Product("Double Espresso", 6));
            products.Add(new Product("Matcha Latte", 11));
            products.Add(new Product("Chai Latte", 9));
            products.Add(new Product("Vietnamese Coffee", 7));

            cmbProducts.DataSource = products; // Ürün listesini ComboBox bileþenine baðlýyoruz.
            cmbProducts.DisplayMember = "Name"; // ComboBox'ta görünen metnin ürün adý olmasýný saðlýyoruz.

            // Çalýþan nesnelerini oluþturup listeye ekliyoruz.
            employees.Add(new Employee("Robjin"));
            employees.Add(new Employee("Jasmine"));
            employees.Add(new Employee("Merve"));
            employees.Add(new Employee("Yaðýz"));
            employees.Add(new Employee("Gizem"));

            InitializeSideProducts(); // Yan ürünlerin baþlatýlmasý.
            UpdateEmployeeList(); // Formda çalýþan listesinin güncellenmesi.
        }

        private void InitializeSideProducts()
        {
            // Yan ürünleri CheckedListBox bileþenine ekliyoruz.
            clbSideProducts.Items.Add("Oat Milk");
            clbSideProducts.Items.Add("Irish Syrup");
            clbSideProducts.Items.Add("Whipped Cream");
            clbSideProducts.Items.Add("Vanilla Syrup");
            clbSideProducts.Items.Add("Hazelnut Syrup");
            clbSideProducts.Items.Add("Coconut Milk");
            clbSideProducts.Items.Add("Caramel Drizzle");
            clbSideProducts.Items.Add("Almond Milk");
            clbSideProducts.Items.Add("Honey");
            clbSideProducts.Items.Add("Cinnamon Powder");
        }

        private void UpdateEmployeeList()
        {
            lstEmployees.Items.Clear(); // Listeyi temizliyoruz.

            // Tüm çalýþanlarýn durumunu listeye ekliyoruz.
            foreach (var employee in employees)
            {
                string status = employee.IsAvailable ? "Available" : "Busy"; // Çalýþanýn durumu.
                lstEmployees.Items.Add($"{employee.Name} - {status}"); // Çalýþan ismi ve durumu listeye ekleniyor.
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Kullanýcýnýn adý ve ürün bilgisi kontrol ediliyor.
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) || cmbProducts.SelectedItem == null)
            {
                MessageBox.Show("Please enter a customer name and select a product."); // Boþ alan hatasý mesajý.
                return;
            }

            var customer = new Customer(txtCustomerName.Text); // Müþteri nesnesi oluþturuluyor.
            var product = (Product)cmbProducts.SelectedItem; // Seçilen ürün alýnýyor.

            // Seçilen yan ürünleri sipariþe ekliyoruz.
            foreach (var item in clbSideProducts.CheckedItems)
            {
                product.SideProducts.Add(item.ToString());
            }

            var order = new Order(customer, product); // Sipariþ nesnesi oluþturuluyor.

            orderQueue.Enqueue(order); // Sipariþ kuyruðuna ekleniyor.
            lstOrders.Items.Add($"{customer.Name} ordered {product.Name} with {string.Join(", ", product.SideProducts)}"); // Sipariþ detayý listeye ekleniyor.
            ProcessOrders(); // Sipariþlerin iþlenmesi.
        }

        private void ProcessOrders()
        {
            if (orderQueue.Count == 0) return; // Sipariþ kuyruðu boþsa iþlem yapma.

            bool isEmployeeAvailable = false; // Boþta çalýþan kontrol bayraðý.
            foreach (var employee in employees)
            {
                if (employee.IsAvailable && orderQueue.Count > 0)
                {
                    var order = orderQueue.Dequeue(); // Sipariþi kuyruðtan al.
                    employee.ProcessOrder(order); // Çalýþan sipariþi iþliyor.
                    lstOrders.Items.Add($"Order for {order.Customer.Name} assigned to {employee.Name}");
                    isEmployeeAvailable = true; // En az bir çalýþan bulundu.
                }
            }

            if (!isEmployeeAvailable)
            {
                MessageBox.Show("All employees are busy. Please wait for an available employee."); // Tüm çalýþanlar doluysa uyarý.
            }

            UpdateEmployeeList(); // Çalýþan listesi güncelleniyor.
        }

        private void ShowStatistics()
        {
            lstStatistics.Items.Clear(); // Ýstatistik listesini temizliyoruz.

            // Her çalýþan için sipariþ sayýsý ve toplam süre bilgilerini listeye ekliyoruz.
            foreach (var employee in employees)
            {
                lstStatistics.Items.Add($"{employee.Name}: {employee.OrdersProcessed} orders, Total time: {employee.TotalProcessingTime} seconds");
            }
        }

        private void btnShowStats_Click(object sender, EventArgs e)
        {
            ShowStatistics(); // Ýstatistiklerin görüntülenmesi.
        }
    }

}
