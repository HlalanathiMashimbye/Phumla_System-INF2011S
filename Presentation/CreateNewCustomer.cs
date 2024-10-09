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
            createNewCustomerClosed = false;
        }

        // Event handler for the confirm button click event
        // Event handler for the confirm button click event
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

            // Check if all required fields are filled
            if (string.IsNullOrEmpty(custID) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(status))
            {
                MessageBox.Show("All fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate customer ID format
            bool validID = validateID(custID);
            if (!validID)
            {
                MessageBox.Show("Invalid customer ID format. It must be a 13-digit number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate phone number format
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d+$"))
            {
                MessageBox.Show("Invalid phone number. It must contain only digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate email format
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email address format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the customer already exists
            if (customerController.CustomerExists(custID))
            {
                MessageBox.Show("A customer with this ID already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Create a new Customer instance
                Customer newCustomer = new Customer(custID, name, surname, phone, email, address, status, balance);

                // Add customer to the DataSet (this is considered a success)
                customerController.DataMaintenance(newCustomer, DBOperation.Add);

                // No need to wait for finalization, consider success after DataMaintenance
                MessageBox.Show("New customer added successfully to the dataset!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to notify that a customer was created
                CustomerCreated?.Invoke();

                // Close the form after success
                this.Close();
            }
        }
        // Event handler for the CustomerID textbox text changed event
        private void CustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        // Validates the customer ID format
        private bool validateID(string customerID)
        {
            if (customerID.Length != 13)
            {
                return false;
            }
            for (int i = 0; i < customerID.Length; i++)
            {
                if (!char.IsDigit(customerID[i]))
                {
                    return false;
                }
            }
            bool validBirthDate = validateBirthDate(customerID);
            bool validGender = validateGender(customerID);
            bool validCitizenship = validateCitizenship(customerID);
            bool validLuhnCheck = validLuhn(customerID); //I am not too sure if this is failsafe but it is in-line with the algorithm online.
            return validBirthDate && validGender && validCitizenship && validLuhnCheck;
        }

        // Validates the birth date portion of the customer ID
        virtual protected bool validateBirthDate(string customerID)
        {
            int year = int.Parse(customerID.Substring(0, 2));
            int month = int.Parse(customerID.Substring(2, 2));
            int day = int.Parse(customerID.Substring(4, 2));
            if (year < 0 || year > 99 || month < 1 || month > 12 || day < 1 || day > 31)
            {
                //MessageBox.Show("Invalid Birthdate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Validates the gender portion of the customer ID
        private bool validateGender(string customerID)
        {
            int genderDigit = int.Parse(customerID.Substring(6, 4));
            bool valid = (genderDigit >= 0 && genderDigit <= 4999) || (genderDigit >= 5000 && genderDigit <= 9999);
            if (!valid)
            {
                //MessageBox.Show("Invalid Gender identifier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        // Validates the citizenship portion of the customer ID
        private bool validateCitizenship(string customerID)
        {
            int citizenshipDigit = int.Parse(customerID.Substring(10, 1));
            bool valid = citizenshipDigit == 0 || citizenshipDigit == 1;
            if (!valid)
            {
                //MessageBox.Show("Invalid Citizenship identifier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        // Performs the Luhn check on the customer ID
        private bool validLuhn(string customerID)
        {
            int sum = 0;
            bool isSecond = false;
            bool isValid = false;

            for (int i = 0; i < customerID.Length; i++)
            {
                int digit = int.Parse(customerID[i].ToString());
                if (isSecond)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
                }
                sum += digit;
                isSecond = !isSecond;
            }

            isValid = (sum % 10 == 0);
            if (!isValid)
            {
                //MessageBox.Show("Invalid Luhn check.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (sum % 10 == 0);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public bool createNewCustomerClosed { get; private set; }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            createNewCustomerClosed = true;
        }

        private void Address_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
