namespace CoffeeOrderSimulation.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCustomerName = new TextBox();
            cmbProducts = new ComboBox();
            lstOrders = new ListBox();
            lstEmployees = new ListBox();
            btnPlaceOrder = new Button();
            lstStatistics = new ListBox();
            btnShowStats = new Button();
            clbSideProducts = new CheckedListBox();
            SuspendLayout();
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(77, 41);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(120, 23);
            txtCustomerName.TabIndex = 0;
            // 
            // cmbProducts
            // 
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(257, 41);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(121, 23);
            cmbProducts.TabIndex = 1;
            // 
            // lstOrders
            // 
            lstOrders.FormattingEnabled = true;
            lstOrders.ItemHeight = 15;
            lstOrders.Location = new Point(479, 41);
            lstOrders.Name = "lstOrders";
            lstOrders.Size = new Size(269, 94);
            lstOrders.TabIndex = 2;
            // 
            // lstEmployees
            // 
            lstEmployees.FormattingEnabled = true;
            lstEmployees.ItemHeight = 15;
            lstEmployees.Location = new Point(479, 159);
            lstEmployees.Name = "lstEmployees";
            lstEmployees.Size = new Size(269, 94);
            lstEmployees.TabIndex = 3;
            // 
            // btnPlaceOrder
            // 
            btnPlaceOrder.Location = new Point(257, 275);
            btnPlaceOrder.Name = "btnPlaceOrder";
            btnPlaceOrder.Size = new Size(120, 23);
            btnPlaceOrder.TabIndex = 4;
            btnPlaceOrder.Text = "Place Order";
            btnPlaceOrder.UseVisualStyleBackColor = true;
            // 
            // lstStatistics
            // 
            lstStatistics.FormattingEnabled = true;
            lstStatistics.ItemHeight = 15;
            lstStatistics.Location = new Point(479, 275);
            lstStatistics.Name = "lstStatistics";
            lstStatistics.Size = new Size(269, 94);
            lstStatistics.TabIndex = 5;
            // 
            // btnShowStats
            // 
            btnShowStats.Location = new Point(257, 346);
            btnShowStats.Name = "btnShowStats";
            btnShowStats.Size = new Size(121, 23);
            btnShowStats.TabIndex = 6;
            btnShowStats.Text = "Show Stats";
            btnShowStats.UseVisualStyleBackColor = true;
            // 
            // clbSideProducts
            // 
            clbSideProducts.FormattingEnabled = true;
            clbSideProducts.Location = new Point(257, 87);
            clbSideProducts.Name = "clbSideProducts";
            clbSideProducts.Size = new Size(121, 148);
            clbSideProducts.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(clbSideProducts);
            Controls.Add(btnShowStats);
            Controls.Add(lstStatistics);
            Controls.Add(btnPlaceOrder);
            Controls.Add(lstEmployees);
            Controls.Add(lstOrders);
            Controls.Add(cmbProducts);
            Controls.Add(txtCustomerName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCustomerName;
        private ComboBox cmbProducts;
        private ListBox lstOrders;
        private ListBox lstEmployees;
        private Button btnPlaceOrder;
        private ListBox lstStatistics;
        private Button btnShowStats;
        private CheckedListBox clbSideProducts;
    }
}
