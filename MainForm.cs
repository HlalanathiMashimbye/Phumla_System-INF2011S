using System;
using System.Windows.Forms;
using Phumla_System.Business;
using Phumla_System.Data;

namespace Phumla_System
{
    public partial class MainForm : Form
    {
        private RoomController roomController;
        private CustomerController customerController;
        private BookingController bookingController;

        public MainForm()
        {
            InitializeComponent();
            roomController = new RoomController();
            customerController = new CustomerController();
            bookingController = new BookingController();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            roomDataGridView.DataSource = roomController.AllRooms;
            customerDataGridView.DataSource = customerController.AllCustomers;
            bookingDataGridView.DataSource = bookingController.AllBookings;
        }

        private void addRoomButton_Click(object sender, EventArgs e)
        {
            var room = new Room(roomIdTextBox.Text, roomNumberTextBox.Text, roomTypeTextBox.Text, "Deluxe", "Available", decimal.Parse(roomPriceTextBox.Text));
            roomController.DataMaintenance(room, DB.DBOperation.Add);
            LoadData();
        }

        private void updateRoomButton_Click(object sender, EventArgs e)
        {
            var room = new Room(roomIdTextBox.Text, roomNumberTextBox.Text, roomTypeTextBox.Text, "Deluxe", "Available", decimal.Parse(roomPriceTextBox.Text));
            roomController.DataMaintenance(room, DB.DBOperation.Change);
            LoadData();
        }

        private void deleteRoomButton_Click(object sender, EventArgs e)
        {
            var room = new Room(roomIdTextBox.Text, null, null, null, null, 0);
            roomController.DataMaintenance(room, DB.DBOperation.Delete);
            LoadData();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer(customerIdTextBox.Text, customerNameTextBox.Text, customerContactTextBox.Text, "john.doe@example.com", "123 Main St", "Male", "0123456789", 0);
            customerController.DataMaintenance(customer, DB.DBOperation.Add);
            LoadData();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer(customerIdTextBox.Text, customerNameTextBox.Text, customerContactTextBox.Text, "john.doe@example.com", "123 Main St", "Male", "0123456789", 0);
            customerController.DataMaintenance(customer, DB.DBOperation.Change);
            LoadData();
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer(customerIdTextBox.Text, null, null, null, null, null, null, 0);
            customerController.DataMaintenance(customer, DB.DBOperation.Delete);
            LoadData();
        }

        private void addBookingButton_Click(object sender, EventArgs e)
        {
            DateTime checkInDate = DateTime.Parse(bookingCheckInDateTextBox.Text);
            DateTime checkOutDate = DateTime.Parse(bookingCheckOutDateTextBox.Text);

            var booking = new Booking(bookingIdTextBox.Text, bookingCustomerIdTextBox.Text, bookingRoomIdTextBox.Text, checkInDate, checkOutDate);
            bookingController.DataMaintenance(booking, DB.DBOperation.Add);
            LoadData();
        }

        private void updateBookingButton_Click(object sender, EventArgs e)
        {
            DateTime checkInDate = DateTime.Parse(bookingCheckInDateTextBox.Text);
            DateTime checkOutDate = DateTime.Parse(bookingCheckOutDateTextBox.Text);

            var booking = new Booking(bookingIdTextBox.Text, bookingCustomerIdTextBox.Text, bookingRoomIdTextBox.Text, checkInDate, checkOutDate);
            bookingController.DataMaintenance(booking, DB.DBOperation.Change);
            LoadData();
        }

        private void deleteBookingButton_Click(object sender, EventArgs e)
        {
            var booking = new Booking(bookingIdTextBox.Text, null, null, DateTime.MinValue, DateTime.MinValue);
            bookingController.DataMaintenance(booking, DB.DBOperation.Delete);
            LoadData();
        }
    }
}
