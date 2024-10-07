using System;
using System.Linq;
using System.Windows.Forms;
using Phumla_System.Business;

namespace Phumla_System
{
    public partial class BookingSearch : Form
    {
        private BookingController bookingController;

        public BookingSearch()
        {
            InitializeComponent();
            bookingController = new BookingController(); // Initialize the BookingController
            bookingSearchClosed = false;
        }

        private void BookingSearch_Load(object sender, EventArgs e)
        {
            // Optional: Any initialization logic on form load
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string custID = custIDTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(custID))
            {
                if (ValidateCustomerID(custID))
                {
                    DisplayBookings(custID);
                }
                // If validation fails, the error message will already be shown
            }
            else
            {
                MessageBox.Show("Please enter a Customer ID.");
            }
        }

        private void DisplayBookings(string custID)
        {
            bookingInfoListBox.Items.Clear(); // Clear previous results

            var bookings = bookingController.AllBookings.Where(b => b.CustID == custID).ToList();

            if (bookings.Count > 0)
            {
                foreach (var booking in bookings)
                {
                    // Display relevant booking details on separate lines
                    bookingInfoListBox.Items.Add($"Booking ID: {booking.BookingID}");
                    bookingInfoListBox.Items.Add($"Room ID: {booking.RoomID}");
                    bookingInfoListBox.Items.Add($"CheckIn: {booking.CheckInDate}");
                    bookingInfoListBox.Items.Add($"CheckOut: {booking.CheckOutDate}");
                    bookingInfoListBox.Items.Add($"Status: {booking.Status}");
                    bookingInfoListBox.Items.Add(new string('-', 50));
                }
            }
            else
            {
                MessageBox.Show("No bookings found for the entered Customer ID.");
            }
        }

        // Add Customer ID validation method here
        private bool ValidateCustomerID(string customerID)
        {
            if (customerID.Length != 13)
            {
                MessageBox.Show("Customer ID must be 13 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            for (int i = 0; i < customerID.Length; i++)
            {
                if (!char.IsDigit(customerID[i]))
                {
                    MessageBox.Show("Customer ID must contain only digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Validate additional portions like BirthDate, Gender, Citizenship, and Luhn Check
            if (!ValidateBirthDate(customerID) || !ValidateGender(customerID) || !ValidateCitizenship(customerID) || !ValidLuhnCheck(customerID))
            {
                return false;
            }

            return true;
        }

        private bool ValidateBirthDate(string customerID)
        {
            int year = int.Parse(customerID.Substring(0, 2));
            int month = int.Parse(customerID.Substring(2, 2));
            int day = int.Parse(customerID.Substring(4, 2));

            if (year < 0 || year > 99 || month < 1 || month > 12 || day < 1 || day > 31)
            {
                MessageBox.Show("Invalid Birthdate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidateGender(string customerID)
        {
            int genderDigit = int.Parse(customerID.Substring(6, 4));
            bool valid = (genderDigit >= 0 && genderDigit <= 4999) || (genderDigit >= 5000 && genderDigit <= 9999);
            if (!valid)
            {
                MessageBox.Show("Invalid Gender identifier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        private bool ValidateCitizenship(string customerID)
        {
            int citizenshipDigit = int.Parse(customerID.Substring(10, 1));
            bool valid = citizenshipDigit == 0 || citizenshipDigit == 1;
            if (!valid)
            {
                MessageBox.Show("Invalid Citizenship identifier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        private bool ValidLuhnCheck(string customerID)
        {
            int sum = 0;
            bool isSecond = false;

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

            bool isValid = (sum % 10 == 0);
            if (!isValid)
            {
                MessageBox.Show("Invalid Luhn check.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValid;
        }

        private void bookingInfoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BookingSearch_Load_1(object sender, EventArgs e)
        {

        }

        public bool bookingSearchClosed { get; private set; }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            bookingSearchClosed = true;
        }
    }
}
