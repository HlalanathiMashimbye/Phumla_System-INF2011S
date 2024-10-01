﻿using Phumla_System.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Phumla_System
{
    public partial class CreateBookingForm : Form
    {
        #region Data Members
        private BookingController bookingController;
        private Booking booking;
        private Customer customer;
        private CustomerController customerController;
        private Collection<Customer> customers;
        public bool createBookingClosed = false;
        #endregion

        #region Constructor
        public CreateBookingForm(BookingController aBookingController, CustomerController aCustomerController)
        {
            InitializeComponent();
            bookingController = aBookingController;
            customerController = aCustomerController;
            customers = customerController.AllCustomers;
            createBookingClosed = false;
        }
        #endregion

        #region Form Events
        private void CreateBookingForm_Load(object sender, EventArgs e)
        {
            ShowAll(false);
        }

        private void CreateBookingForm_Activated(object sender, EventArgs e)
        {
            ShowAll(false);
        }

        private void CreateBookingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            createBookingClosed = true;
        }
        #endregion

        #region Utility Methods
        private void ShowAll(bool value)
        {
            custIDLabel.Visible = value;
            noOfGuestsLabel.Visible = value;
            checkInLabel.Visible = value;
            checkOutLabel.Visible = value;
            requirementsLabel.Visible = value;

            custIDTextBox.Visible = value;
            noOfGuestsTextBox.Visible = value;
            checkInDateTimePicker.Visible = value;
            checkOutDateTimePicker.Visible = value;
            requirementsTextBox.Visible = value;

            checkAvailButton.Visible = value;
            exitButton.Visible = value;
        }

        private void ClearAll()
        {
            custIDTextBox.Text = "";
            noOfGuestsTextBox.Text = "";
            checkInDateTimePicker.Value = DateTime.Now;
            checkOutDateTimePicker.Value = DateTime.Now.AddDays(1);
            requirementsTextBox.Text = "";
        }

        private void PopulateObject()
        {
            booking = new Booking(
                custIDTextBox.Text,
                checkInDateTimePicker.Value,
                checkOutDateTimePicker.Value,
                "Confirmed",
                noOfGuestsTextBox.Text,
                requirementsTextBox.Text
            );
        }

        private bool CustomerHasBooking(string custID)
        {
            // Check if customer has any booking
            return bookingController.CustomerHasBooking(custID);
        }
        #endregion

        #region Button Click Events
        private void checkAvailButton_Click_1(object sender, EventArgs e)
        {
            // Ensure the customer ID is not empty
            if (string.IsNullOrWhiteSpace(custIDTextBox.Text) || custIDTextBox.Text.Length != 13)
            {
                MessageBox.Show("Please enter a valid customer ID.");
                return;
            }

            string custID = custIDTextBox.Text;

            // Check if the customer exists
            if (!customerController.CustomerExists(custID))
            {
                // If the customer does not exist, open the CreateNewCustomer form
                CreateNewCustomer createNewCustomerForm = new CreateNewCustomer();
                createNewCustomerForm.CustomerCreated += OnCustomerCreated; // Subscribe to the event
                createNewCustomerForm.ShowDialog(); // Show the form as a dialog
                return; // Exit the method
            }

            // Check if the customer has an existing booking
  

            // If no booking exists, proceed with the new booking
            PopulateObject();

            if (booking.IsBookingValid())
            {
                // Check room availability and assign a room or handle waitlist
                AssignRoomBasedOnAvailability();
            }
            else
            {
                MessageBox.Show("Invalid booking dates. Check-out must be after Check-in.");
            }
        }

        private void OnCustomerCreated()
        {
            // Refresh the customer list
            customers = customerController.AllCustomers;
        }


        // Method to check room availability and assign a room
        private void AssignRoomBasedOnAvailability()
        {
            DateTime checkInDate = booking.CheckInDate;
            DateTime checkOutDate = booking.CheckOutDate;

            // Get available rooms for the date range
            var availableRooms = bookingController.GetAvailableRoomsForDateRange(checkInDate, checkOutDate);

            if (availableRooms.Count > 0)
            {
                // Assign a random available room
                Random rand = new Random();
                int randomIndex = rand.Next(availableRooms.Count);
                int assignedRoomID = availableRooms[randomIndex].RoomID;

                // Assign the room to the booking
                booking.AssignRoom(assignedRoomID);
                bookingController.DataMaintenance(booking, Data.DB.DBOperation.Add);

                if (bookingController.FinalizeChanges(booking))
                {
                    MessageBox.Show($"Room {assignedRoomID} has been assigned to the booking.", "Room Assigned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    ShowAll(false);
                }
                else
                {
                    MessageBox.Show("Failed to create booking. Please try again.");
                }
            }
            else
            {
                // No rooms available, prompt the receptionist
                DialogResult result = MessageBox.Show("No rooms are available for the selected date range. Do you want to assign to the waitlist (Room 0) or choose another date?", "No Rooms Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Assign to waitlist (Room 0)
                    booking.AssignRoom(0);
                    bookingController.DataMaintenance(booking, Data.DB.DBOperation.Add);

                    if (bookingController.FinalizeChanges(booking))
                    {
                        MessageBox.Show("Booking has been added to the waitlist (Room 0).", "Waitlist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAll();
                        ShowAll(false);
                    }
                    else
                    {
                        MessageBox.Show("Failed to create booking. Please try again.");
                    }
                }
                else
                {
                    // Allow receptionist to choose a new date
                    MessageBox.Show("Please choose another date range.", "Choose New Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Menu Item Click Events
        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerListing customerListingForm = new CustomerListing();
            customerListingForm.Show();
        }

        private void createNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewCustomer createNewCustomerForm = new CreateNewCustomer();
            createNewCustomerForm.CustomerCreated += OnCustomerCreated; // Subscribe to the event
            createNewCustomerForm.Show();
        }

        private void newBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingSearch bookingSearchForm = new BookingSearch();
            bookingSearchForm.Show();
        }

        private void changeBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBooking changeBookingForm = new ChangeBooking();
            changeBookingForm.Show();
        }

        private void cancelBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelBooking cancelBookingForm = new CancelBooking();
            cancelBookingForm.Show();
        }

        private void occupancyLevelReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OccupancyLevelReport occupancyLevelReport = new OccupancyLevelReport();
            occupancyLevelReport.Show();
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Notifications logic can be added here
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Additional logic can be added if needed
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateBookingForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
