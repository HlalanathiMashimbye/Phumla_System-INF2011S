using Phumla_System.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Xml;

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
        private string bookingID;
        #endregion

        #region Property Methods
        public Customer FindCustomer()
        {
            foreach (Customer cust in customers)
            {
                if (cust.CustID == custIDTextBox.Text)
                {
                    nameTextBox.Text = cust.Name;
                    surnameTextBox.Text = cust.Surname;
                    //phoneTextBox.Text = cust.Phone;
                    //emailTextBox.Text = cust.Email;
                    return cust;
                }
            }
            return null;
        }

        private void findCustomerButton_Click(object sender, EventArgs e)
        {
            customer = FindCustomer();
            if (customer == null)
            {
                MessageBox.Show("Customer not found. Please enter a valid Customer ID."); // need to program it to create a new customer
            }
            else
            {
                ShowAll(true);
                bookingID = Guid.NewGuid().ToString(); // Generate a new booking ID
            }
        }
        #endregion

        #region Constructor
        public CreateBookingForm(BookingController aBookingController, CustomerController aCustomerController)
        {
            InitializeComponent();
            bookingController = aBookingController;
            customerController = aCustomerController;
            customers = customerController.AllCustomers;
            customer = new Customer();
            booking = new Booking();
            createBookingClosed = false;
        }
        #endregion

        #region Utility Methods
        private void ShowAll(bool value)
        {
            custIDLabel.Visible = value;
            nameLabel.Visible = value;
            surnameLabel.Visible = value;
            checkInLabel.Visible = value;
            checkOutLabel.Visible = value;
            //requestTypeLabel.Visible = value; //FIGURE OUT???
            //requestDetailsLabel.Visible = value; //???
            requirementsLabel.Visible = value;
            

            custIDTextBox.Visible = value;
            nameTextBox.Visible = value;
            surnameTextBox.Visible = value;
            checkInDateTimePicker.Visible = value;
            checkOutDateTimePicker.Visible = value;
            //requestTypeTextBox.Visible = value;
            //requestDetailsTextBox.Visible = value;
            requirementsTextBox.Visible = value;

            checkAvailButton.Visible = value;
            exitButton.Visible = value;
        }

        private void ClearAll()
        {
            custIDTextBox.Text = "";
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
            checkInDateTimePicker.Value = DateTime.Now;
            checkOutDateTimePicker.Value = DateTime.Now.AddDays(1);
            //requestTypeTextBox.Text = "";
            //requestDetailsTextBox.Text = "";

        }

        private void PopulateObject()
        {
            booking = new Booking(
                bookingID,
                custIDTextBox.Text,
                checkInDateTimePicker.Value,
                checkOutDateTimePicker.Value,
                "Confirmed"
            );
            booking.SetRequest(
                //requestTypeTextBox.Text,
                //requestDetailsTextBox.Text,
                DateTime.Now
            );
        }
        #endregion

        #region Form Events
        private void CreateBooking_Load(object sender, EventArgs e)
        {
            ShowAll(false);
        }

        private void CreateBooking_Activated(object sender, EventArgs e)
        {
            ShowAll(false);
        }

        private void checkAvailButton_Click(object sender, EventArgs e)
        {
            if (customer == null)
            {
                MessageBox.Show("Please find a valid customer first.");
                return;
            }

            PopulateObject();

            if(booking.IsBookingValid())
            {
                bookingController.DataMaintenance(booking, Data.DB.DBOperation.Add);
                if (bookingController.FinalizeChanges(booking))
                {
                    MessageBox.Show("Booked created successfully.");
                    ClearAll();
                    ShowAll(false);
                }
                else
                {
                    MessageBox.Show("Failed to create booking. Please try again");
                }
            }
            else
            {
                MessageBox.Show("Invalid booking dates. Check-out must be after Check-in.");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateBookingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            createBookingClosed = true;
        }
        #endregion
    }
}
