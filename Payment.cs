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

        // Define season dates and rates
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
            // The label and event handler are already set in the Designer file
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

            // Update the total amount on the form
            totalTxtbox.Text = totalAmount.ToString("C");
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
                    total += 550m; // Using Low Season rate as default
                }
            }
            return total;
        }

        private void ProcessPayment()
        {
            try
            {
                currentBooking.UpdateStatus("Confirmed");
                bookingDB.DataSetChange(currentBooking, DBOperation.Change);
                if (bookingDB.UpdateDataSource(currentBooking))
                {
                    // Update room status to "Occupied"
                    if (currentBooking.RoomID.HasValue)
                    {
                        var room = roomDB.AllRooms.FirstOrDefault(r => r.RoomID == currentBooking.RoomID.Value);
                        if (room != null)
                        {
                            room.Status = "Occupied";
                            roomDB.DataSetChange(room, DBOperation.Change);
                            roomDB.UpdateDataSource();
                        }
                    }

                    MessageBox.Show($"Payment of {totalAmount:C} processed successfully for booking ID {currentBooking.BookingID}.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: Failed to update booking status in the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}");
            }
        }
    }
}