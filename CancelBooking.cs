using System;
using System.Windows.Forms;
using Phumla_System.Business;

namespace Phumla_System
{
    public partial class CancelBooking : Form
    {
        private BookingController bookingController;
        private ReceptionistController receptionistController;

        public CancelBooking()
        {
            InitializeComponent();
            bookingController = new BookingController();
            receptionistController = new ReceptionistController();
        }

        private void CancelBooking_Load(object sender, EventArgs e)
        {
            LoadBookings(); // Load bookings into DataGridView
        }

        private void LoadBookings()
        {
            var bookings = bookingController.AllBookings;
            dataGridViewBookings.DataSource = bookings;

            // Optionally hide irrelevant columns
            dataGridViewBookings.Columns["BookingID"].Visible = false; // BookingID should be hidden
            dataGridViewBookings.Columns["CustID"].Visible = false; // Ensure CustID matches column name

            // Show CustomerName instead of CustID
            dataGridViewBookings.Columns["CustomerName"].HeaderText = "Customer Name";
            dataGridViewBookings.Columns["RoomID"].HeaderText = "Room Number";
            dataGridViewBookings.Columns["Status"].HeaderText = "Status";
        }


        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.SelectedRows.Count > 0)
            {
                // Get selected booking
                var selectedBooking = (Booking)dataGridViewBookings.SelectedRows[0].DataBoundItem;

                // Prompt for receptionist email and password
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                if (ValidateReceptionist(email, password))
                {
                    // Cancel booking (Set room to null and status to 'Cancelled')
                    selectedBooking.RoomID = 0;
                    selectedBooking.Status = "Cancelled";

                    // Update booking in database
                    bookingController.DataMaintenance(selectedBooking, Phumla_System.Data.DB.DBOperation.Change);

                    // Save changes to database
                    if (bookingController.FinalizeChanges())
                    {
                        MessageBox.Show("Booking cancelled successfully.");
                        LoadBookings(); // Refresh the bookings list
                    }
                    else
                    {
                        MessageBox.Show("Failed to cancel booking.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid receptionist credentials.");
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to cancel.");
            }
        }

        private bool ValidateReceptionist(string email, string password)
        {
            // Validate credentials using the ReceptionistController
            return receptionistController.ValidateCredentials(email, password);
        }

        private void dataGridViewBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
