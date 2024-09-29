using System;
using System.Data;
using System.Windows.Forms;
using Phumla_System.Business;
using Phumla_System.Data;

namespace Phumla_System
{
    public partial class CustomerListing : Form
    {
        private CustomerDB customerDB;  // Instance of CustomerDB

        public CustomerListing()
        {
            InitializeComponent();
            customerDB = new CustomerDB(); // Initialize the CustomerDB instance
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the form
        }


        private void CustomerListing_Load(object sender, EventArgs e)
        {
            LoadCustomers();  // Load customers when the form loads
        }

        private void LoadCustomers()
        {
            // Clear existing data in the DataGridView
            dataGridViewCustomers.DataSource = null;

            // Bind the DataGridView to the customers collection
            dataGridViewCustomers.DataSource = customerDB.AllCustomers;

            // Optionally set auto-generate columns to true if needed
            dataGridViewCustomers.AutoGenerateColumns = true;

            // Optionally set some properties for better UI
            dataGridViewCustomers.Columns["CustID"].HeaderText = "Customer ID";
            dataGridViewCustomers.Columns["Name"].HeaderText = "Name";
            dataGridViewCustomers.Columns["Surname"].HeaderText = "Surname";
            dataGridViewCustomers.Columns["Phone"].HeaderText = "Phone";
            dataGridViewCustomers.Columns["Email"].HeaderText = "Email";
            dataGridViewCustomers.Columns["Address"].HeaderText = "Address";
            dataGridViewCustomers.Columns["Balance"].HeaderText = "Balance";
            dataGridViewCustomers.Columns["Status"].HeaderText = "Status";
        }

        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
