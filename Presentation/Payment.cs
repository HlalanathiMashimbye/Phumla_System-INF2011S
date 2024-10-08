using System;
using System.Linq;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using Phumla_System.Business;
using Phumla_System.Data;
using static Phumla_System.Data.DB;

namespace Phumla_System
{
    public partial class Payment : Form
    {
        private BookingDB bookingDB;
        private RoomDB roomDB;
        private CustomerDB customerDB;
        private Booking currentBooking;
        private decimal totalAmount;
        private bool paymentClosed;

        private static readonly (DateTime Start, DateTime End, decimal Rate)[] Seasons = new[]
        {
            (new DateTime(2024, 12, 1), new DateTime(2024, 12, 7), 550m),  // Low Season
            (new DateTime(2024, 12, 8), new DateTime(2024, 12, 15), 750m), // Mid Season
            (new DateTime(2024, 12, 16), new DateTime(2024, 12, 31), 995m) // High Season
        };

        public Payment(Booking booking)
        {
            InitializeComponent();
            this.bookingDB = new BookingDB();
            this.roomDB = new RoomDB();
            this.customerDB = new CustomerDB();
            this.currentBooking = booking;
            InitializeForm();
            paymentClosed = false;
        }

        private void InitializeForm()
        {
            totalTxtbox.ReadOnly = true;
            customerID.Text = currentBooking.CustID;
            customerID.ReadOnly = true;
            CalculateAndDisplayTotal();
        }

        private void CalculateAndDisplayTotal()
        {
            totalAmount = CalculateTotalAmount(currentBooking.CheckInDate, currentBooking.CheckOutDate);
            totalTxtbox.Text = string.Format("R {0:N2}", totalAmount);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ProcessPayment();
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
                bool paymentSuccessful = ProcessPaymentTransaction();

                if (paymentSuccessful)
                {
                    currentBooking.UpdateStatus("Confirmed");
                    bookingDB.DataSetChange(currentBooking, DBOperation.Change);

                    if (bookingDB.UpdateDataSource(currentBooking))
                    {
                        UpdateRoomStatus();
                        SendConfirmationEmail();
                        MessageBox.Show($"Payment of R {totalAmount:N2} processed successfully for booking ID {currentBooking.BookingID}. Booking status updated to Confirmed. Confirmation email sent.");
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
                    HandleFailedPayment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}. The booking status was not changed.");
            }
        }

        private void UpdateRoomStatus()
        {
            if (currentBooking.RoomID.HasValue && currentBooking.CheckInDate.Date == DateTime.Today)
            {
                var room = roomDB.AllRooms.FirstOrDefault(r => r.RoomID == currentBooking.RoomID.Value);
                if (room != null)
                {
                    room.Status = "Occupied";
                    roomDB.DataSetChange(room, DBOperation.Change);
                    roomDB.UpdateDataSource();
                }
            }
        }

        private void HandleFailedPayment()
        {
            currentBooking.UpdateStatus("Pending");
            bookingDB.DataSetChange(currentBooking, DBOperation.Change);
            bookingDB.UpdateDataSource(currentBooking);
            MessageBox.Show("Payment processing failed. The booking remains in Pending status. Please try again or use a different payment method.");
            this.DialogResult = DialogResult.Cancel;
        }

        private bool ProcessPaymentTransaction()
        {
            // This is a placeholder for the actual payment processing logic
            // In a real-world scenario, this would interact with a payment gateway
            // For demonstration, let's simulate a successful payment 90% of the time
            Random rnd = new Random();
            return rnd.Next(100) < 90;
        }

        private void SendConfirmationEmail()
        {
            try
            {
                var customer = customerDB.AllCustomers.FirstOrDefault(c => c.CustID == currentBooking.CustID);
                if (customer == null || string.IsNullOrWhiteSpace(customer.Email))
                {
                    MessageBox.Show("Unable to send confirmation email. Customer email not found.");
                    return;
                }

                string subject = "Booking Confirmation - Phumla System";
                string body = GenerateEmailBody();

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("hlalianoint@gmail.com", "ztic qpwi snua vkln");
                    smtpClient.EnableSsl = true; // Enable SSL for secure connection

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress("hlalianoint@gmail.com");
                        mailMessage.To.Add(customer.Email);
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true; // Setting the body to HTML format

                        smtpClient.Send(mailMessage);
                    }
                }

                MessageBox.Show("Confirmation email sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending confirmation email: {ex.Message}");
            }
        }

        private string GenerateEmailBody()
        {
            var room = roomDB.AllRooms.FirstOrDefault(r => r.RoomID == currentBooking.RoomID);
       

            return $@"
                <html>
                <body>
                    <h2>Booking Confirmation</h2>
                    <p>Dear Valued Guest,</p>
                    <p>Thank you for choosing Phumla System. Your booking has been confirmed.</p>
                    <h3>Booking Details:</h3>
                    <ul>
                        <li>Booking ID: {currentBooking.BookingID}</li>
                        <li>Check-In Date: {currentBooking.CheckInDate.ToShortDateString()}</li>
                        <li>Check-Out Date: {currentBooking.CheckOutDate.ToShortDateString()}</li>
                        <li>Number of Guests: {currentBooking.NumberOfGuests}</li>
                        <li>Total Amount Paid: R {totalAmount:N2}</li>
                    </ul>
                    <p>If you have any questions or need to make changes to your reservation, please contact us at www.phumla.com or 012 342 5467.</p>
                    <p>We look forward to welcoming you!</p>
                    <p>Best regards,<br>Phumla System Team</p>
                </body>
                </html>";
        }
    }
}
