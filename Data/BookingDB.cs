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
            INNER JOIN Customer c ON b.CustID = c.CustID";
        #endregion

        #region Constructor
        public BookingDB() : base()
        {
            bookings = new Collection<Booking>();
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
        protected override void FillDataSet(string sqlQuery, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataAdapter = new SqlDataAdapter(sqlQuery, connection);
                connection.Open();

                try
                {
                    DataAdapter.Fill(DataSet, tableName);

                    // Manually create the UpdateCommand
                    CreateUpdateCommand((SqlDataAdapter)DataAdapter);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error filling DataSet: " + ex.Message);
                }
            }
        }

        private void CreateUpdateCommand(SqlDataAdapter adapter)
        {
            string updateSQL = @"
                UPDATE Booking 
                SET CustID = @CustID, 
                    RoomID = @RoomID, 
                    CheckInDate = @CheckInDate, 
                    CheckOutDate = @CheckOutDate, 
                    Status = @Status, 
                    RequestDetails = @RequestDetails
                WHERE BookingID = @BookingID";

            adapter.UpdateCommand = new SqlCommand(updateSQL, SqlConnection);

            adapter.UpdateCommand.Parameters.Add("@CustID", SqlDbType.NVarChar, 50, "CustID");
            adapter.UpdateCommand.Parameters.Add("@RoomID", SqlDbType.NVarChar, 50, "RoomID");
            adapter.UpdateCommand.Parameters.Add("@CheckInDate", SqlDbType.DateTime, 0, "CheckInDate");
            adapter.UpdateCommand.Parameters.Add("@CheckOutDate", SqlDbType.DateTime, 0, "CheckOutDate");
            adapter.UpdateCommand.Parameters.Add("@Status", SqlDbType.NVarChar, 50, "Status");
            adapter.UpdateCommand.Parameters.Add("@RequestDetails", SqlDbType.NVarChar, -1, "RequestDetails");
            adapter.UpdateCommand.Parameters.Add("@BookingID", SqlDbType.Int, 0, "BookingID");

            // Optimistic concurrency: assume the row hasn't changed since it was retrieved
            adapter.UpdateCommand.Parameters.Add("@Original_BookingID", SqlDbType.Int, 0, "BookingID").SourceVersion = DataRowVersion.Original;
        }

        private void AddBookingsToCollection()
        {
            DataTable dataTable = DataSet.Tables[table];

            foreach (DataRow row in dataTable.Rows)
            {
                // Safely parse BookingID
                if (!int.TryParse(row["BookingID"]?.ToString(), out int bookingID))
                {
                    // Log an error or skip if parsing fails
                    Console.WriteLine($"Invalid BookingID found: {row["BookingID"]}");
                    continue;
                }

                string custID = row["CustID"].ToString();
                string customerName = row["Name"].ToString();

                // Safely parse RoomID if it's nullable
                int roomID = row["RoomID"] != DBNull.Value ? int.Parse(row["RoomID"].ToString()) : -1;

                DateTime checkInDate = DateTime.Parse(row["CheckInDate"].ToString());
                DateTime checkOutDate = DateTime.Parse(row["CheckOutDate"].ToString());
                string status = row["Status"].ToString();
                string requestDetails = row["RequestDetails"]?.ToString();

                Booking booking = new Booking(bookingID, custID, checkInDate, checkOutDate, status)
                {
                    CustomerName = customerName
                };

                if (roomID != -1) // Only assign room if it is valid
                {
                    booking.AssignRoom(roomID);
                }

                booking.SetRequest(requestDetails);

                bookings.Add(booking);
            }
        }


        private DataRow FindRow(int bookingID)
        {
            DataTable dataTable = DataSet.Tables[table];
            DataRow[] rows = dataTable.Select($"BookingID = '{bookingID}'");
            return rows.Length > 0 ? rows[0] : null;
        }

        private void FillDataRow(DataRow row, Booking booking)
        {
            row["BookingID"] = booking.BookingID;
            row["CustID"] = booking.CustID;
            row["RoomID"] = booking.RoomID ;
            row["CheckInDate"] = booking.CheckInDate;
            row["CheckOutDate"] = booking.CheckOutDate;
            row["Status"] = booking.Status;
            row["RequestDetails"] = booking.RequestDetails ?? (object)DBNull.Value;
        }
        #endregion

        #region Public Methods
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

        public bool UpdateDataSource(Booking booking)
        {
            if (DataAdapter == null || ((SqlDataAdapter)DataAdapter).UpdateCommand == null)
            {
                // Re-initialize DataAdapter if it's null or UpdateCommand is not set
                FillDataSet(sqlLocal, table);
            }

            // Find the row to update
            DataRow[] rows = DataSet.Tables[table].Select($"BookingID = {booking.BookingID}");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                // Update the row with new values
                FillDataRow(row, booking);
            }

            return base.UpdateDataSource(sqlLocal, table);
        }
        #endregion
    }
}