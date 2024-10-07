using System;
using System.Windows.Forms;
using Phumla_System.Business;

namespace Phumla_System
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            // Create a mock booking object with the required details for testing
            Booking testBooking = new Booking(
                bookingID: 1,
                custID: "0301015939186",
                checkInDate: new DateTime(2024, 12, 24),
                checkOutDate: new DateTime(2024, 12, 28),
                numberOfGuests: "2",
                status: "Pending", // Added the missing 'status' parameter
                details: "None" // Added the missing 'requestDetails' parameter
            );

            // Show the payment form with the test booking
            Payment paymentForm = new Payment(testBooking);
            paymentForm.ShowDialog();
        }

    }
}
