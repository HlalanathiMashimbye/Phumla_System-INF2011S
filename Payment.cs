using System;
using System.Linq;
using System.Windows.Forms;
using Phumla_System.Business;
using Phumla_System.Data;
using static Phumla_System.Data.DB;

namespace Phumla_System
{
    public partial class Payment : Form
    {
        private BookingDB bookingDB;
        private RoomDB roomDB;
        private Booking currentBooking;
        private decimal totalAmount;

        private static readonly (DateTime Start, DateTime End, decimal Rate)[] Seasons = new[]
        {
            (new DateTime(2024, 12, 1), new DateTime(2024, 12, 7), 550m),  // Low Season
            (new DateTime(2024, 12, 8), new DateTime(2024, 12, 15), 750m), // Mid Season
            (new DateTime(2024, 12, 16), new DateTime(2024, 12, 31), 995m) // High Season
        };

        public Payment()
        {
            InitializeComponent();
            this.bookingDB = new BookingDB();
            this.roomDB = new RoomDB();
            InitializeForm();
        }

        private void InitializeForm()
        {
            totalTxtbox.ReadOnly = true;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                FindBookingAndCalculateTotal();
                if (currentBooking != null)
                {
                    ProcessPayment();
                }
                MessageBox.Show("Booking Confirmed.");
                MainForm mainForm = new MainForm();
                mainForm.ShowDialog();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text.Length != 16)
            {
                MessageBox.Show("Please enter a valid 16-digit card number.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(customerID.Text))
            {
                MessageBox.Show("Please enter the Customer ID.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(expiryDate.Text) || expiryDate.Text.Length != 5)
            {
                MessageBox.Show("Please enter a valid expiry date (MM/YY).");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text) || textBox3.Text.Length != 3)
            {
                MessageBox.Show("Please enter a valid 3-digit security code.");
                return false;
            }

            return true;
        }

        private void FindBookingAndCalculateTotal()
        {
            string custId = customerID.Text.Trim();

            currentBooking = bookingDB.AllBookings.FirstOrDefault(b =>
                b.CustID == custId && b.Status == "Pending");

            if (currentBooking == null)
            {
                MessageBox.Show("No pending booking found for the given Customer ID.");
                return;
            }

            var room = roomDB.AllRooms.FirstOrDefault(r => r.RoomID == currentBooking.RoomID);
            if (room == null)
            {
                MessageBox.Show("Error: Room not found for the booking.");
                return;
            }

            totalAmount = CalculateTotalAmount(currentBooking.CheckInDate, currentBooking.CheckOutDate);

            totalTxtbox.Text = string.Format("R {0:N2}", totalAmount);
        }

        private decimal CalculateTotalAmount(DateTime checkIn, DateTime checkOut)
        {
            decimal total = 0;
            for (DateTime date = checkIn; date < checkOut; date = date.AddDays(1))
            {
                var season = Seasons.FirstOrDefault(s => date >= s.Start && date <= s.End);
                if (season != default)
                {
                    total += season.Rate;
                }
                else
                {
                    // Default rate if date is outside defined seasons
                    total += 550m; // Using Low Season rate as the default
                }
            }
            return total;
        }

        private void ProcessPayment()
        {
            try
            {
                // Simulate payment processing
                bool paymentSuccessful = ProcessPaymentTransaction();

                if (paymentSuccessful)
                {
                    // Update booking status to "Confirmed" using the Booking class method
                    currentBooking.UpdateStatus("Confirmed");
                    bookingDB.DataSetChange(currentBooking, DBOperation.Change);

                    if (bookingDB.UpdateDataSource(currentBooking))
                    {
                        // Update room status to "Occupied" if the check-in date is today
                        if (currentBooking.RoomID.HasValue)
                        {
                            var room = roomDB.AllRooms.FirstOrDefault(r => r.RoomID == currentBooking.RoomID.Value);
                            if (room != null && currentBooking.CheckInDate.Date == DateTime.Today)
                            {
                                room.Status = "Occupied";
                                roomDB.DataSetChange(room, DBOperation.Change);
                                roomDB.UpdateDataSource();
                            }
                        }

                        MessageBox.Show($"Payment of R {totalAmount:N2} processed successfully for booking ID {currentBooking.BookingID}. Booking status updated to Confirmed.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed to update booking status in the database. The booking may still be in Pending status.");
                    }
                }
                else
                {
                    // Ensure the booking remains in "Pending" status
                    currentBooking.UpdateStatus("Pending");
                    bookingDB.DataSetChange(currentBooking, DBOperation.Change);
                    bookingDB.UpdateDataSource(currentBooking);

                    MessageBox.Show("Payment processing failed. The booking remains in Pending status. Please try again or use a different payment method.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}. The booking status was not changed.");
            }
        }

        private bool ProcessPaymentTransaction()
        {
            // This is a placeholder for the actual payment processing logic
            // In a real-world scenario, this would interact with a payment gateway
            // For demonstration, let's simulate a successful payment 90% of the time
            Random rnd = new Random();
            return rnd.Next(100) < 90;
        }
    }
}