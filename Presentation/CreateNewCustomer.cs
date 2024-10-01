using System;
using System.Windows.Forms;
using Phumla_System.Business;
using static Phumla_System.Data.DB;

namespace Phumla_System
{
    public partial class CreateNewCustomer : Form
    {
        private CustomerController customerController;

        // Event to notify that a customer was created
        public event Action CustomerCreated;

        public CreateNewCustomer()
        {
            InitializeComponent();
            customerController = new CustomerController();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string custID = CustomerID.Text.Trim();
            string name = CustomerName.Text.Trim();
            string surname = Surname.Text.Trim();
            string phone = Telephone.Text.Trim();
            string email = EmailAddress.Text.Trim();
            string address = Address.Text.Trim();
            string status = Status.SelectedItem?.ToString();
            decimal balance = Balance.Value;

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

                    // Trigger the event to notify that a customer was created
                    CustomerCreated?.Invoke();

                    this.Close();  // Close the form after success
                }
                else
                {
                    MessageBox.Show("Failed to add new customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
