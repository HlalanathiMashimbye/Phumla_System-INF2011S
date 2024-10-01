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
                DisplayBookings(custID);
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

        private void bookingInfoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
