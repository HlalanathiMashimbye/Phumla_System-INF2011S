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
        }

        private void ReservationCancellationReport_Load(object sender, EventArgs e)
        {
            LoadCancelledBookings();
        }

        private void LoadCancelledBookings()
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
                        CancellationReason = booking.RequestDetails // Assuming RequestDetails is used for cancellation reason
                    });
                }
            }

            dataGridViewCancellations.DataSource = reportData;
            lblTotalCancellations.Text = $"Total Cancellations: {reportData.Count}";
        }

        // You might want to add a refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCancelledBookings();
        }

        public bool reservationCancellationReportClosed { get; private set; }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            reservationCancellationReportClosed = true;
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