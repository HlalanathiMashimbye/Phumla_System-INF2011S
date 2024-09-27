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

        public BookingTestForm()
        {
            InitializeComponent();
            bookingController = new BookingController();
            RefreshBookingList();
        }

        private void RefreshBookingList()
        {
            lstBookings.Items.Clear();
            foreach (var booking in bookingController.AllBookings)
            {
                lstBookings.Items.Add($"{booking.BookingID} - {booking.CustID} - {booking.Status}");
            }
        }

        private Booking GetBookingFromForm()
        {
            Booking booking = new Booking(
                txtBookingID.Text,
                txtCustID.Text,
                dtpCheckIn.Value,
                dtpCheckOut.Value,
                cmbStatus.SelectedItem.ToString()
            );

            booking.AssignRoom(txtRoomID.Text);
            booking.SetRequest(txtRequestType.Text, txtRequestDetails.Text, dtpRequestDate.Value);

            return booking;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Booking newBooking = GetBookingFromForm();
            bookingController.DataMaintenance(newBooking, DB.DBOperation.Add);
            RefreshBookingList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Booking updatedBooking = GetBookingFromForm();
            bookingController.DataMaintenance(updatedBooking, DB.DBOperation.Change);
            RefreshBookingList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstBookings.SelectedItem != null)
            {
                string selectedBookingId = lstBookings.SelectedItem.ToString().Split('-')[0].Trim();
                Booking bookingToDelete = bookingController.AllBookings.First(b => b.BookingID == selectedBookingId);
                bookingController.DataMaintenance(bookingToDelete, DB.DBOperation.Delete);
                RefreshBookingList();
            }
        }

        private void txtBookingID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstBookings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BookingTestForm_Load(object sender, EventArgs e)
        {

        }
    }
}