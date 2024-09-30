using System;
using System.Linq;
using System.Windows.Forms;
using Phumla_System.Business;
using Phumla_System.Data;

namespace Phumla_System.Forms
{
    public partial class BookingTestForm : Form
    {
        private BookingController bookingController;
        private CustomerController customerController;
        private RoomController roomController;

        public BookingTestForm()
        {
            InitializeComponent();
            bookingController = new BookingController();
            customerController = new CustomerController();
            roomController = new RoomController();
            RefreshBookingList();
        }

        private void RefreshBookingList()
        {
            lstBookings.Items.Clear();
            foreach (var booking in bookingController.AllBookings)
            {
                var customer = customerController.AllCustomers.FirstOrDefault(c => c.CustID == booking.CustID);
                var room = roomController.AllRooms.FirstOrDefault(r => r.RoomID == booking.RoomID);

                string customerInfo = customer != null ? $"{customer.Name} {customer.Surname}" : "Unknown Customer";
                string roomInfo = room != null ? $"Room {room.RoomID}" : "Unknown Room";

                lstBookings.Items.Add($"Booking {booking.BookingID} - {customerInfo} - {roomInfo} - {booking.CheckInDate.ToShortDateString()} to {booking.CheckOutDate.ToShortDateString()} - {booking.Status}");
            }
        }

        private Booking GetBookingFromForm()
        {
            // Validate the check-in and check-out dates
            if (dtpCheckIn.Value >= dtpCheckOut.Value)
            {
                MessageBox.Show("Check-in date must be earlier than the check-out date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Prevent further processing
            }

            // Ensure BookingID is parsed as int
            if (!int.TryParse(txtBookingID.Text, out int bookingID))
            {
                MessageBox.Show("Invalid Booking ID. Please enter a valid integer.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            Booking booking = new Booking(
                bookingID, // Use parsed integer
                txtCustID.Text,
                dtpCheckIn.Value,
                dtpCheckOut.Value,
                cmbStatus.SelectedItem.ToString()
            );

            //booking.AssignRoom(txtRoomID.Text);
            booking.SetRequest(txtRequestDetails.Text);

            return booking;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Booking newBooking = GetBookingFromForm();
            if (newBooking != null)
            {
                bookingController.DataMaintenance(newBooking, DB.DBOperation.Add);
                RefreshBookingList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Booking updatedBooking = GetBookingFromForm();
            if (updatedBooking != null)
            {
                bookingController.DataMaintenance(updatedBooking, DB.DBOperation.Change);
                RefreshBookingList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstBookings.SelectedItem != null)
            {
                string selectedBookingId = lstBookings.SelectedItem.ToString().Split('-')[0].Trim().Split(' ')[1];
                Booking bookingToDelete = bookingController.AllBookings.First(b => b.BookingID.ToString() == selectedBookingId); // Convert to string for comparison
                bookingController.DataMaintenance(bookingToDelete, DB.DBOperation.Delete);
                RefreshBookingList();
            }
        }

        private void txtBookingID_TextChanged(object sender, EventArgs e)
        {
            // Placeholder for future functionality, if needed
        }

        private void lstBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Placeholder for future functionality, if needed
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Placeholder for future functionality, if needed
        }

        private void BookingTestForm_Load(object sender, EventArgs e)
        {
            // Placeholder for future functionality, if needed
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            // Placeholder for future functionality, if needed
        }

        private void lblBookingID_Click(object sender, EventArgs e)
        {
            // Placeholder for future functionality, if needed
        }

        private void lblCustID_Click(object sender, EventArgs e)
        {
            // Placeholder for future functionality, if needed
        }

        private void BookingTestForm_Load_1(object sender, EventArgs e)
        {
            // Placeholder for future functionality, if needed
        }
    }
}
