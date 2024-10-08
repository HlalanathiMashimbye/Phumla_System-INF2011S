using System;
using System.Windows.Forms;
using Phumla_System.Business;
using Phumla_System.Data;
using Phumla_System.Presentation;
using static Phumla_System.Data.DB;

namespace Phumla_System
{
    public partial class ChangeBooking : Form
    {
        private Booking currentBooking;
        private BookingController bookingController;
        private CustomerController customerController;

        public ChangeBooking()
        {
            InitializeComponent();
            bookingController = new BookingController();
            customerController = new CustomerController();
            changeBookingClosed = false;
        }

        private void ChangeBooking_Load(object sender, EventArgs e)
        {
            LoadBookings();
            SetupStatusComboBox();
            SetupNumGuestsComboBox();
            WireUpEventHandlers();
        }

        private void LoadBookings()
        {
            var bookings = bookingController.AllBookings;

            if (bookings == null || bookings.Count == 0)
            {
                MessageBox.Show("No bookings found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridViewBookings.DataSource = bookings;

            // Hide irrelevant columns
            dataGridViewBookings.Columns["BookingID"].Visible = false;
            dataGridViewBookings.Columns["CustID"].Visible = false;

            // Show CustomerName instead of CustID
            dataGridViewBookings.Columns["CustomerName"].HeaderText = "Customer Name";
            dataGridViewBookings.Columns["RoomID"].HeaderText = "Room Number";
            dataGridViewBookings.Columns["Status"].HeaderText = "Status";
        }

        private void SetupStatusComboBox()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Confirmed", "Pending", "Cancelled" });
            cmbStatus.SelectedIndex = 0;
        }

        private void SetupNumGuestsComboBox()
        {
            cmbNumGuests.Items.Clear();
            cmbNumGuests.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            cmbNumGuests.SelectedIndex = 0;
        }

        private void WireUpEventHandlers()
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            dataGridViewBookings.SelectionChanged += DataGridViewBookings_SelectionChanged;
        }

        private void DataGridViewBookings_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBookings.SelectedRows.Count > 0)
            {
                currentBooking = (Booking)dataGridViewBookings.SelectedRows[0].DataBoundItem;
                DisplayBookingDetails();
            }
        }

        private void DisplayBookingDetails()
        {
            if (currentBooking != null)
            {
                txtBookingID.Text = currentBooking.BookingID.ToString();
                cmbNumGuests.SelectedItem = currentBooking.NumberOfGuests;
                dtpCheckInDate.Value = currentBooking.CheckInDate;
                dtpCheckOutDate.Value = currentBooking.CheckOutDate;
                cmbStatus.SelectedItem = currentBooking.Status;
                txtRequestDetails.Text = currentBooking.RequestDetails;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentBooking == null)
            {
                MessageBox.Show("Please select a booking to change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidateInput())
            {
                try
                {
                    UpdateBooking();
                    if (bookingController.FinalizeChanges(currentBooking))
                    {
                        MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBookings(); // Refresh the bookings list
                    }
                    else
                    {
                        //MessageBox.Show("Failed to update booking in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show($"Error saving booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtRequestDetails.Text))
            {
                MessageBox.Show("Request details must be entered.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (cmbNumGuests.SelectedItem == null)
            {
                MessageBox.Show("Please select the number of guests.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void UpdateBooking()
        {
            currentBooking.NumberOfGuests = cmbNumGuests.SelectedItem.ToString();
            currentBooking.CheckInDate = dtpCheckInDate.Value;
            currentBooking.CheckOutDate = dtpCheckOutDate.Value;
            currentBooking.Status = cmbStatus.SelectedItem.ToString();
            currentBooking.RequestDetails = txtRequestDetails.Text;

            bookingController.DataMaintenance(currentBooking, DBOperation.Change);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadBookings();
        }

            public bool changeBookingClosed { get; private set; }


            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                base.OnFormClosing(e);
                changeBookingClosed = true;
            }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
    
}
