using Phumla_System.Data;
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

namespace Phumla_System
{
    public partial class OccupancyLevelReport : Form
    {
        public OccupancyLevelReport()
        {
            InitializeComponent();
        }

        private BookingController bookingController;
        private RoomController roomController;

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            if (endDate < startDate )
            {
                MessageBox.Show("End date cannot be before start date.");
                return;
            }

            DataTable occupancyData = GetOccupancyData(startDate, endDate); 
            dataGridViewReport.DataSource = occupancyData;
        }

        private DataTable GetOccupancyData(DateTime startDate, DateTime endDate)
        {
            DataTable occupancyData = new DataTable();

    
            occupancyData.Columns.Add("RoomNumber", typeof(string));
            occupancyData.Columns.Add("CustomerID", typeof(string));
            occupancyData.Columns.Add("CheckInDate", typeof(DateTime));
            occupancyData.Columns.Add("CheckOutDate", typeof(DateTime));
            occupancyData.Columns.Add("Status", typeof(string));

            try
            {
                BookingDB bookingDB = new BookingDB();
                RoomDB roomDB = new RoomDB();

                foreach (Booking booking in bookingDB.AllBookings)
                {
                    if ((booking.CheckInDate <= endDate) && (booking.CheckOutDate >= startDate))
                    {
                        Room room = roomDB.AllRooms.FirstOrDefault(r => r.RoomID == booking.RoomID);

                        if (room != null)
                        {
                            occupancyData.Rows.Add(
                                room.Number,            
                                booking.CustID,         
                                booking.CheckInDate,    
                                booking.CheckOutDate,   
                                booking.Status          
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching occupancy data: " + ex.Message);
            }

            return occupancyData;
        }

    }
}

