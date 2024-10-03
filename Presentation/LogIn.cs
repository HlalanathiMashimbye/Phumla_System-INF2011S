using System;
using System.Windows.Forms;
using Phumla_System.Data;
using Phumla_System.Business;

namespace Phumla_System
{
    public partial class LogIn : Form
    {
        private ReceptionistController receptionistController; // Controller to manage receptionists
        private BookingController bookingController; // Add this line
        private CustomerController customerController; // Add this line

        public LogIn()
        {
            InitializeComponent();
            receptionistController = new ReceptionistController(); // Initialize the receptionist controller
            bookingController = new BookingController(); // Initialize the booking controller
            customerController = new CustomerController(); // Initialize the customer controller

            // Set the password TextBox to mask input
            enterPassword.PasswordChar = '*'; // Mask the password with '*'
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            string email = enterEmail.Text.Trim(); // Assuming you have an emailTextBox for email input
            string password = enterPassword.Text.Trim(); // Assuming you have a passwordTextBox for password input

            if (IsValidCredentials(email, password))
            {
                // If valid, proceed to the next part of your application
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Open the main dashboard
                CreateBookingForm createBookingForm = new CreateBookingForm(bookingController, customerController); // Pass the required parameters
                createBookingForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidCredentials(string email, string password)
        {
            // Check if the email and password are correct using the receptionist controller
            return receptionistController.ValidateCredentials(email, password);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
