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
            Console.WriteLine("ChangeBooking constructor called");
            InitializeComponent();
            Console.WriteLine("InitializeComponent called");

            bookingDB = new BookingDB();
            LoadBooking(bookingID);
            SetupStatusComboBox();
            WireUpEventHandlers();
        }


        private void SetupStatusComboBox()
        {
            Console.WriteLine("SetupStatusComboBox method called");
            if (cmbStatus == null)
            {
                Console.WriteLine("cmbStatus is null");
                return;
            }

            cmbStatus.Items.Clear();
            Console.WriteLine("Items cleared");

            cmbStatus.Items.AddRange(new string[] { "Confirmed", "Cancelled", "Completed" });
            Console.WriteLine($"Items added. Count: {cmbStatus.Items.Count}");

            if (currentBooking != null && !string.IsNullOrEmpty(currentBooking.Status))
            {
                cmbStatus.SelectedItem = currentBooking.Status;
                Console.WriteLine($"Selected item set to: {currentBooking.Status}");
            }
            else
            {
                cmbStatus.SelectedIndex = 0;
                Console.WriteLine("Selected index set to 0");
            }
        }

        private void LoadBooking(int bookingID)
        {
            currentBooking = bookingDB.AllBookings.FirstOrDefault(b => b.BookingID == bookingID);
            if (currentBooking == null )
            {
                MessageBox.Show($"Booking with ID {bookingID} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtBookingID.Text = currentBooking.BookingID.ToString();
            //txtCustomerID.Text = currentBooking.CustID;
            //txtCustomerName.Text = currentBooking.CustomerName;
            txtRoomID.Text = currentBooking.RoomID.ToString();
            dtpCheckInDate.Value = currentBooking.CheckInDate;
            dtpCheckOutDate.Value = currentBooking.CheckOutDate;
            //cmbStatus.SelectedItem = currentBooking.Status;
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
            if (currentBooking == null)
            {
                MessageBox.Show("No booking is currently loaded. Unable to save changes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidateInput())
            {
                try
                {
                    UpdateBooking();
                    bookingDB.DataSetChange(currentBooking, DBOperation.Change);
                    if (bookingDB.UpdateDataSource(currentBooking))
                    {
                        MessageBox.Show("Booking updated successfully in the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update booking in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (currentBooking == null)
            {
                MessageBox.Show("No booking is currently loaded. Unable to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (int.TryParse(txtRoomID.Text, out int roomID))
                {
                    currentBooking.RoomID = roomID;
                }
                else
                {
                    MessageBox.Show("Invalid Room ID. Please enter a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                currentBooking.CheckInDate = dtpCheckInDate.Value;
                currentBooking.CheckOutDate = dtpCheckOutDate.Value;
                currentBooking.Status = cmbStatus.SelectedItem?.ToString() ?? currentBooking.Status;
                currentBooking.RequestDetails = txtRequestDetails.Text;

                // If you need to update other fields, do so here

                MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void WireUpEventHandlers()
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void ChangeBooking_Load(object sender, EventArgs e)
        {
            Console.WriteLine("ChangeBooking_Load event fired");
            ManuallyPopulateStatusComboBox();
        }

        private void ManuallyPopulateStatusComboBox()
        {
            Console.WriteLine("ManuallyPopulateStatusComboBox called");
            if (cmbStatus == null)
            {
                Console.WriteLine("cmbStatus is null in ManuallyPopulateStatusComboBox");
                return;
            }

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Confirmed");
            cmbStatus.Items.Add("Cancelled");
            cmbStatus.Items.Add("Completed");
            Console.WriteLine($"Items manually added. Count: {cmbStatus.Items.Count}");
        }

        private void cmbNumGuests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
