using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phumla_System.Business;
using Phumla_System.Data;
using static Phumla_System.Data.DB;

namespace Phumla_System
{
    public partial class ChangeBooking : Form
    {

        private Booking currentBooking;
        private BookingDB bookingDB;

        public ChangeBooking()
        {
            InitializeComponent();
        }

        public ChangeBooking(int bookingID)
        {
            bookingDB = new BookingDB();
            LoadBooking(bookingID);
            SetupStatusComboBox();
            WireUpEventHandlers();
        }

        private void SetupStatusComboBox()
        {
            if (cmbStatus != null)
            {
                cmbStatus.Items.Clear();
                cmbStatus.Items.AddRange(new string[] { "Confirmed", "Cancelled", "Completed" });
            }
        }

        private void LoadBooking(int bookingID)
        {
            currentBooking = bookingDB.AllBookings.FirstOrDefault(b => b.BookingID == bookingID);
            if (currentBooking == null )
            {
                MessageBox.Show("Booking not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtBookingID.Text = currentBooking.BookingID.ToString();
            //txtCustomerID.Text = currentBooking.CustID;
            //txtCustomerName.Text = currentBooking.CustomerName;
            txtRoomID.Text = currentBooking.RoomID;
            dtpCheckInDate.Value = currentBooking.CheckInDate;
            dtpCheckOutDate.Value = currentBooking.CheckOutDate;
            cmbStatus.SelectedItem = currentBooking.Status;
            txtRequestDetails.Text = currentBooking.RequestDetails;

            // Make BookingID and CustomerName read-only
            txtBookingID.ReadOnly = true;
            //txtCustomerName.ReadOnly = true;
        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                UpdateBooking();
                bookingDB.DataSetChange(currentBooking, DBOperation.Change);
                if (bookingDB.UpdateDataSource(currentBooking))
                {
                    MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update booking.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtBookingID.Text))
            {
                MessageBox.Show("Booking ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dtpCheckOutDate.Value <= dtpCheckInDate.Value)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Add more validation as needed (DONT DELETE FOR NOW)

            return true;
        }

        private void UpdateBooking()
        {
            //currentBooking.CustID = txtCustomerID.Text;
            currentBooking.RoomID = txtRoomID.Text;
            currentBooking.CheckInDate = dtpCheckInDate.Value;
            currentBooking.CheckOutDate = dtpCheckOutDate.Value;
            currentBooking.Status = cmbStatus.SelectedItem.ToString();
            currentBooking.RequestDetails = txtRequestDetails.Text;
        }

        private void WireUpEventHandlers()
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }


    }
}
