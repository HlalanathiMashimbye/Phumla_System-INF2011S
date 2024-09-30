using System;
using System.Windows.Forms;
using Phumla_System.Business;
using static Phumla_System.Data.DB;

namespace Phumla_System
{
    public partial class CreateNewCustomer : Form
    {
        private CustomerController customerController;

        public CreateNewCustomer()
        {
            InitializeComponent();
            customerController = new CustomerController();  // Initialize controller
        }

        private void CreateNewCustomer_Load(object sender, EventArgs e)
        {
            
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string custID = CustomerID.Text.Trim();  // Get CustID from the CustomerID TextBox
            string name = CustomerName.Text.Trim();   // Get Customer Name from the CustomerName TextBox
            string surname = Surname.Text.Trim();
            string phone = Telephone.Text.Trim();
            string email = EmailAddress.Text.Trim();
            string address = Address.Text.Trim();
            string status = Status.SelectedItem?.ToString();  // Get the selected status
            decimal balance = Balance.Value;  // Get the balance value

            // Check if the customer already exists
            if (customerController.CustomerExists(custID))
            {
                MessageBox.Show("A customer with this ID already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Create a new Customer instance
                Customer newCustomer = new Customer(custID, name, surname, phone, email, address, status, balance);

                // Add customer to the database
                customerController.DataMaintenance(newCustomer, DBOperation.Add);

                // Finalize and update the data source
                if (customerController.FinalizeChanges())
                {
                    MessageBox.Show("New customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();  // Close the form after success
                }
                else
                {
                    MessageBox.Show("Failed to add new customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Name_TextChanged(object sender, EventArgs e)
        {
            // This method can be removed if not used
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // This method can be removed if not used
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // This method can be removed if not used
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // This method can be removed if not used
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {
            // This method can be removed if not used
        }
    }
}
