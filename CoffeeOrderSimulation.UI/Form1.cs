using CoffeeOrderSimulation.UI.Models;

namespace CoffeeOrderSimulation.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeData(); // Form y�klenirken gerekli veri yap�lar�n ve �al��anlar�n ba�lat�lmas�.
        }

        private List<Employee> employees = new List<Employee>(); // �al��an nesnelerini tutacak liste.
        private Queue<Order> orderQueue = new Queue<Order>(); // Sipari�leri tutan bir kuyruk.
        private List<Product> products = new List<Product>(); // Kahve �r�nlerini tutan liste.

        private void InitializeData()
        {
            // Kahve �r�nlerini listeye ekliyoruz.
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

            cmbProducts.DataSource = products; // �r�n listesini ComboBox bile�enine ba�l�yoruz.
            cmbProducts.DisplayMember = "Name"; // ComboBox'ta g�r�nen metnin �r�n ad� olmas�n� sa�l�yoruz.

            // �al��an nesnelerini olu�turup listeye ekliyoruz.
            employees.Add(new Employee("Robjin"));
            employees.Add(new Employee("Jasmine"));
            employees.Add(new Employee("Merve"));
            employees.Add(new Employee("Ya��z"));
            employees.Add(new Employee("Gizem"));

            InitializeSideProducts(); // Yan �r�nlerin ba�lat�lmas�.
            UpdateEmployeeList(); // Formda �al��an listesinin g�ncellenmesi.
        }

        private void InitializeSideProducts()
        {
            // Yan �r�nleri CheckedListBox bile�enine ekliyoruz.
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

            // T�m �al��anlar�n durumunu listeye ekliyoruz.
            foreach (var employee in employees)
            {
                string status = employee.IsAvailable ? "Available" : "Busy"; // �al��an�n durumu.
                lstEmployees.Items.Add($"{employee.Name} - {status}"); // �al��an ismi ve durumu listeye ekleniyor.
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Kullan�c�n�n ad� ve �r�n bilgisi kontrol ediliyor.
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) || cmbProducts.SelectedItem == null)
            {
                MessageBox.Show("Please enter a customer name and select a product."); // Bo� alan hatas� mesaj�.
                return;
            }

            var customer = new Customer(txtCustomerName.Text); // M��teri nesnesi olu�turuluyor.
            var product = (Product)cmbProducts.SelectedItem; // Se�ilen �r�n al�n�yor.

            // Se�ilen yan �r�nleri sipari�e ekliyoruz.
            foreach (var item in clbSideProducts.CheckedItems)
            {
                product.SideProducts.Add(item.ToString());
            }

            var order = new Order(customer, product); // Sipari� nesnesi olu�turuluyor.

            orderQueue.Enqueue(order); // Sipari� kuyru�una ekleniyor.
            lstOrders.Items.Add($"{customer.Name} ordered {product.Name} with {string.Join(", ", product.SideProducts)}"); // Sipari� detay� listeye ekleniyor.
            ProcessOrders(); // Sipari�lerin i�lenmesi.
        }

        private void ProcessOrders()
        {
            if (orderQueue.Count == 0) return; // Sipari� kuyru�u bo�sa i�lem yapma.

            bool isEmployeeAvailable = false; // Bo�ta �al��an kontrol bayra��.
            foreach (var employee in employees)
            {
                if (employee.IsAvailable && orderQueue.Count > 0)
                {
                    var order = orderQueue.Dequeue(); // Sipari�i kuyru�tan al.
                    employee.ProcessOrder(order); // �al��an sipari�i i�liyor.
                    lstOrders.Items.Add($"Order for {order.Customer.Name} assigned to {employee.Name}");
                    isEmployeeAvailable = true; // En az bir �al��an bulundu.
                }
            }

            if (!isEmployeeAvailable)
            {
                MessageBox.Show("All employees are busy. Please wait for an available employee."); // T�m �al��anlar doluysa uyar�.
            }

            UpdateEmployeeList(); // �al��an listesi g�ncelleniyor.
        }

        private void ShowStatistics()
        {
            lstStatistics.Items.Clear(); // �statistik listesini temizliyoruz.

            // Her �al��an i�in sipari� say�s� ve toplam s�re bilgilerini listeye ekliyoruz.
            foreach (var employee in employees)
            {
                lstStatistics.Items.Add($"{employee.Name}: {employee.OrdersProcessed} orders, Total time: {employee.TotalProcessingTime} seconds");
            }
        }

        private void btnShowStats_Click(object sender, EventArgs e)
        {
            ShowStatistics(); // �statistiklerin g�r�nt�lenmesi.
        }
    }

}
