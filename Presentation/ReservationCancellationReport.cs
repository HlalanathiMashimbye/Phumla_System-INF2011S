using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Phumla_System.Business;
using Phumla_System.Data;

namespace Phumla_System
{
    public partial class ReservationCancellationReport : Form
    {
        private BookingDB bookingDB;
        private CustomerDB customerDB;

        public ReservationCancellationReport()
        {
            InitializeComponent();
            bookingDB = new BookingDB();
            customerDB = new CustomerDB();
            reservationCancellationReportClosed = false;
            this.Load += ReservationCancellationReport_Load;
            button1.Click += button1_Click;
        }

        private void ReservationCancellationReport_Load(object sender, EventArgs e)
        {
            LoadCancelledBookings();
        }

        private void LoadCancelledBookings()
        {
            try
            {
                var cancelledBookings = bookingDB.AllBookings.Where(b => b.Status == "Cancelled").ToList();
                var reportData = new List<CancellationReportItem>();
                foreach (var booking in cancelledBookings)
                {
                    var customer = customerDB.AllCustomers.FirstOrDefault(c => c.CustID == booking.CustID);
                    if (customer != null)
                    {
                        reportData.Add(new CancellationReportItem
                        {
                            BookingID = booking.BookingID,
                            CustomerName = $"{customer.Name} {customer.Surname}",
                            CustomerPhone = customer.Phone,
                            CustomerEmail = customer.Email,
                            CancellationReason = booking.RequestDetails
                        });
                    }
                }

                dataGridViewCancellations.DataSource = null;
                dataGridViewCancellations.DataSource = reportData;
                dataGridViewCancellations.Refresh();

                lblTotalCancellations.Text = $"Total Cancellations: {reportData.Count}";

                // Add debug information
                Console.WriteLine($"Loaded {reportData.Count} cancelled bookings");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cancellations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error in LoadCancelledBookings: {ex}");
            }
        }




        public bool reservationCancellationReportClosed { get; private set; }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            reservationCancellationReportClosed = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadCancelledBookings();
        }
    }

    public class CancellationReportItem
    {
        public int BookingID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CancellationReason { get; set; }
    }



}