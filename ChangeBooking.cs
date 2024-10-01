using System;
using System.Linq;
using System.Windows.Forms;
using Phumla_System.Business;
using Phumla_System.Data;
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
        }

        public ChangeBooking(int bookingID, BookingController aBookingController, CustomerController aCustomerController)
        {
            InitializeComponent();

            bookingController = aBookingController;
            customerController = aCustomerController;

            // Debugging: Log the booking ID passed in.
            Console.WriteLine($"Attempting to load booking with ID: {bookingID}");

            LoadBooking(bookingID);
            SetupStatusComboBox();
            SetupNumGuestsComboBox();
            WireUpEventHandlers();
        }

        private void LoadBooking(int bookingID)
        {
            currentBooking = bookingController.AllBookings.FirstOrDefault(b => b.BookingID == bookingID);
            if (currentBooking == null)
            {
                MessageBox.Show($"Booking with ID {bookingID} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Populate the form with booking details
            txtBookingID.Text = currentBooking.BookingID.ToString();
            cmbNumGuests.SelectedItem = currentBooking.NumberOfGuests;
            txtRoomID.Text = currentBooking.RoomID.ToString();
            dtpCheckInDate.Value = currentBooking.CheckInDate;
            dtpCheckOutDate.Value = currentBooking.CheckOutDate;
            cmbStatus.SelectedItem = currentBooking.Status;
            txtRequestDetails.Text = currentBooking.RequestDetails;

            txtBookingID.ReadOnly = true;
        }

        private void SetupStatusComboBox()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Confirmed", "Pending", "Cancelled" });

            if (currentBooking != null && !string.IsNullOrEmpty(currentBooking.Status))
            {
                cmbStatus.SelectedItem = currentBooking.Status;
            }
            else
            {
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void SetupNumGuestsComboBox()
        {
            cmbNumGuests.Items.Clear();
            cmbNumGuests.Items.AddRange(new object[] { 1, 2, 3 });

            if (currentBooking != null && currentBooking.NumberOfGuests != "0")
            {
                cmbNumGuests.SelectedItem = currentBooking.NumberOfGuests;
            }
            else
            {
                cmbNumGuests.SelectedIndex = 0;
            }
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
                    if (bookingController.FinalizeChanges(currentBooking))
                    {
                        MessageBox.Show("Booking updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (cmbNumGuests.SelectedItem == null)
            {
                MessageBox.Show("Please select the number of guests.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtRoomID.Text, out int roomID) || roomID < 0)
            {
                MessageBox.Show("Please enter a valid Room ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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
                int newRoomID = int.Parse(txtRoomID.Text);
                if (newRoomID != currentBooking.RoomID)
                {
                    var availableRooms = bookingController.GetAvailableRoomsForDateRange(dtpCheckInDate.Value, dtpCheckOutDate.Value);
                    if (!availableRooms.Any(r => r.RoomID == newRoomID))
                    {
                        MessageBox.Show("The selected room is not available for the given date range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (currentBooking.RoomID != 0)
                    {
                        bookingController.UpdateRoomStatus((int)currentBooking.RoomID, "Available");
                    }

                    bookingController.AssignRoomToBooking(currentBooking.BookingID, newRoomID);
                }

                currentBooking.NumberOfGuests = cmbNumGuests.SelectedItem.ToString();
                currentBooking.CheckInDate = dtpCheckInDate.Value;
                currentBooking.CheckOutDate = dtpCheckOutDate.Value;
                currentBooking.Status = cmbStatus.SelectedItem.ToString();
                currentBooking.RequestDetails = txtRequestDetails.Text;

                bookingController.DataMaintenance(currentBooking, DBOperation.Change);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void WireUpEventHandlers()
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void ChangeBooking_Load(object sender, EventArgs e)
        {
            SetupStatusComboBox();
            SetupNumGuestsComboBox();
        }

        private void cmbNumGuests_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Add any specific logic for when the number of guests changes, if needed
        }
    }
}
