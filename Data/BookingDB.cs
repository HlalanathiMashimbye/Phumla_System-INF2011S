using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Phumla_System.Business;
using Phumla_System.Properties;
using System.Windows.Forms;

namespace Phumla_System.Data
{
    public class BookingDB : DB
    {
        #region Data Members
        private Collection<Booking> bookings;
        private string table = "Booking";  // Table name in the database
        private string sqlLocal = "SELECT * FROM Booking";  // SQL query to load the bookings
        #endregion

        #region Constructor
        public BookingDB() : base()
        {
            bookings = new Collection<Booking>();
            FillDataSet(sqlLocal, table);  // Load bookings from the database
            AddBookingsToCollection();
        }
        #endregion

        #region Property
        public Collection<Booking> AllBookings
        {
            get { return bookings; }
        }
        #endregion

        #region Private Methods

        // Populate the bookings collection from the dataset
        private void AddBookingsToCollection()
        {
            if (!DataSet.Tables.Contains(table))
            {
                throw new InvalidOperationException($"The specified table '{table}' does not exist in the DataSet.");
            }

            DataTable dataTable = DataSet.Tables[table];
            

            if (dataTable == null)
            {
                // Handle the error, e.g., log it or throw an exception
                throw new InvalidOperationException("The specified table does not exist in the DataSet.");
            }

            foreach (DataRow row in dataTable.Rows)
            {
                string bookingID = row["BookingID"].ToString();
                string custID = row["CustID"].ToString();
                string roomID = row["RoomID"]?.ToString();
                DateTime checkInDate = DateTime.Parse(row["CheckInDate"].ToString());
                DateTime checkOutDate = DateTime.Parse(row["CheckOutDate"].ToString());
                string status = row["Status"].ToString();
                string requestType = row["RequestType"]?.ToString();
                string requestDetails = row["RequestDetails"]?.ToString();
                DateTime requestDate = DateTime.Parse(row["RequestDate"].ToString());

                Booking booking = new Booking(bookingID, custID, checkInDate, checkOutDate, status);
                booking.AssignRoom(roomID);
                booking.SetRequest(requestType, requestDetails, requestDate);

                bookings.Add(booking);
            }
        }


        // Find a DataRow for a specific booking by BookingID
        private DataRow FindRow(string bookingID)
        {
            DataTable dataTable = DataSet.Tables[table];
            DataRow[] rows = dataTable.Select($"BookingID = '{bookingID}'");
            return rows.Length > 0 ? rows[0] : null;
        }

        // Fill a DataRow with booking data
        private void FillDataRow(DataRow row, Booking booking)
        {
            row["BookingID"] = booking.BookingID;
            row["CustID"] = booking.CustID;

            // Handle RoomID: Check for null and assign DBNull.Value if necessary
            if (string.IsNullOrEmpty(booking.RoomID))
                row["RoomID"] = DBNull.Value;
            else
                row["RoomID"] = booking.RoomID;

            row["CheckInDate"] = booking.CheckInDate;
            row["CheckOutDate"] = booking.CheckOutDate;
            row["Status"] = booking.Status;

            // Handle RequestType: Check for null and assign DBNull.Value if necessary
            if (string.IsNullOrEmpty(booking.RequestType))
                row["RequestType"] = DBNull.Value;
            else
                row["RequestType"] = booking.RequestType;

            // Handle RequestDetails: Check for null and assign DBNull.Value if necessary
            if (string.IsNullOrEmpty(booking.RequestDetails))
                row["RequestDetails"] = DBNull.Value;
            else
                row["RequestDetails"] = booking.RequestDetails;

            // Handle RequestDate: Assign DBNull if it's the minimum value (means uninitialized)
            if (booking.RequestDate == DateTime.MinValue)
                row["RequestDate"] = DBNull.Value;
            else
                row["RequestDate"] = booking.RequestDate;
        }


        #endregion

        #region Public Methods

        // Modify the dataset based on the DBOperation (Add, Change, Delete)
        public void DataSetChange(Booking booking, DBOperation operation)
        {
            DataRow row = null;

            switch (operation)
            {
                case DBOperation.Add:
                    row = DataSet.Tables[table].NewRow();
                    FillDataRow(row, booking);
                    DataSet.Tables[table].Rows.Add(row);
                    break;

                case DBOperation.Change:
                    row = FindRow(booking.BookingID);
                    if (row != null)
                    {
                        FillDataRow(row, booking);
                    }
                    break;

                case DBOperation.Delete:
                    row = FindRow(booking.BookingID);
                    if (row != null)
                    {
                        row.Delete();
                    }
                    break;
            }
        }

        // Update the actual database with changes from the dataset
        public bool UpdateDataSource(Booking booking)
        {
            return UpdateDataSource(sqlLocal, table);
        }

        #endregion
    }
}
