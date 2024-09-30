using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Phumla_System.Business;
using Phumla_System.Properties;

namespace Phumla_System.Data
{
    public class BookingDB : DB
    {
        #region Data Members
        private Collection<Booking> bookings;
        private string table = "Booking";
        private string sqlLocal = @"
            SELECT b.BookingID, b.CustID, c.Name, b.RoomID, b.CheckInDate, 
                   b.CheckOutDate, b.Status, b.RequestDetails
            FROM Booking b
            INNER JOIN Customer c ON b.CustID = c.CustID";  // SQL query with join
        #endregion

        #region Constructor
        public BookingDB() : base()
        {
            bookings = new Collection<Booking>();
            // Use FillDataSet to load bookings from the database
            FillDataSet(sqlLocal, table);
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

        // Fill the DataSet by executing the SQL query
        protected override void FillDataSet(string sqlQuery, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(Settings.Default.BookingsDatabaseConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                connection.Open();

                try
                {
                    adapter.Fill(DataSet, tableName);  // Fill DataSet with results from query
                }
                catch (Exception ex)
                {
                    // Handle any exceptions, e.g., log error
                    throw new Exception("Error filling DataSet: " + ex.Message);
                }
            }
        }


        // Populate the bookings collection from the DataSet
        private void AddBookingsToCollection()
        {
            if (!DataSet.Tables.Contains(table))
            {
                throw new InvalidOperationException($"The specified table '{table}' does not exist in the DataSet.");
            }

            DataTable dataTable = DataSet.Tables[table];

            foreach (DataRow row in dataTable.Rows)
            {
                int bookingID = int.Parse(row["BookingID"].ToString());
                string custID = row["CustID"].ToString();
                string customerName = row["Name"].ToString();  // Fetch customer name
                string roomID = row["RoomID"]?.ToString();
                DateTime checkInDate = DateTime.Parse(row["CheckInDate"].ToString());
                DateTime checkOutDate = DateTime.Parse(row["CheckOutDate"].ToString());
                string status = row["Status"].ToString();
                string requestDetails = row["RequestDetails"]?.ToString();

                Booking booking = new Booking(bookingID, custID, checkInDate, checkOutDate, status)
                {
                    CustomerName = customerName  // Assign the customer name
                };
                booking.AssignRoom(roomID);
                booking.SetRequest(requestDetails);

                bookings.Add(booking);
            }
        }

        // Find DataRow for a specific booking by BookingID
        private DataRow FindRow(int bookingID)
        {
            DataTable dataTable = DataSet.Tables[table];
            DataRow[] rows = dataTable.Select($"BookingID = '{bookingID}'");
            return rows.Length > 0 ? rows[0] : null;
        }

        // Fill DataRow with booking data for updates
        private void FillDataRow(DataRow row, Booking booking)
        {
            row["BookingID"] = booking.BookingID;
            row["CustID"] = booking.CustID;

            if (string.IsNullOrEmpty(booking.RoomID))
                row["RoomID"] = DBNull.Value;
            else
                row["RoomID"] = booking.RoomID;

            row["CheckInDate"] = booking.CheckInDate;
            row["CheckOutDate"] = booking.CheckOutDate;
            row["Status"] = booking.Status;

            if (string.IsNullOrEmpty(booking.RequestDetails))
                row["RequestDetails"] = DBNull.Value;
            else
                row["RequestDetails"] = booking.RequestDetails;


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
