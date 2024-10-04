using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;  
using System.Data.SqlClient;
using System.Linq;
using Phumla_System.Business;

namespace Phumla_System.Data
{
    public class BookingDB : DB
    {
        #region Data Members
        private Collection<Booking> bookings;
        private string table = "Booking";
        private string sqlLocal = @"
            SELECT b.BookingID, b.CustID, c.Name, b.RoomID, b.CheckInDate, 
                   b.CheckOutDate, b.Status, b.RequestDetails, b.NumberOfGuests
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

        #region Properties
        public Collection<Booking> AllBookings
        {
            get { return bookings; }
        }
        #endregion

        #region Database Operations
        public void DataSetChange(Booking booking, DB.DBOperation operation)
        {
            DataRow row = null;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    row = DataSet.Tables[table].NewRow();
                    FillDataRow(row, booking);
                    DataSet.Tables[table].Rows.Add(row);
                    break;
                case DB.DBOperation.Change:
                    row = FindRow(booking.BookingID);
                    if (row != null)
                    {
                        FillDataRow(row, booking);
                    }
                    break;
                case DB.DBOperation.Delete:
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
            if (DataAdapter == null)
            {
                FillDataSet(sqlLocal, table);
            }

            // Fetch the row based on BookingID
            DataRow[] rows = DataSet.Tables[table].Select($"BookingID = {booking.BookingID}");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                FillDataRow(row, booking);
            }

            try
            {
                // Try to update the data source
                return base.UpdateDataSource(sqlLocal, table);
            }
            catch (DBConcurrencyException ex)
            {
                //Console.WriteLine($"Concurrency violation occurred: {ex.Message}");

                // Fetch the latest version of the record
                DataSet latestDataSet = FetchLatestData(table, booking.BookingID);

                // Apply changes from local dataset to remote dataset
                ApplyChanges(DataSet, latestDataSet);

                // Try updating again
                return base.UpdateDataSource(sqlLocal, table);
            }
        }

        private DataSet FetchLatestData(string sqlTable, int bookingID)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM {sqlTable} WHERE BookingID = @BookingID", connection);
                da.SelectCommand.Parameters.AddWithValue("@BookingID", bookingID);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                return dataSet;
            }
        }

        private void ApplyChanges(DataSet oldDS, DataSet newDS)
        {
            DataTable oldTable = oldDS.Tables[0];
            DataTable newTable = newDS.Tables[0];

            foreach (DataRow oldRow in oldTable.Rows)
            {
                DataRow newRow = newTable.Rows.Find(oldRow["BookingID"]);
                if (newRow != null && oldRow.RowState == DataRowState.Unchanged)
                {
                    oldRow.AcceptChanges();
                }
            }

            foreach (DataRow newRow in newTable.Rows)
            {
                if (!oldTable.Rows.Contains(newRow["BookingID"]))
                {
                    newRow.SetAdded();
                }
            }
        }


        // New method to get bookings for a specific room
        public Collection<Booking> GetBookingsForRoom(int roomID)
        {
            return new Collection<Booking>(bookings.Where(b => b.RoomID == roomID).ToList());
        }

        // New method to insert a booking and retrieve its BookingID
        public bool InsertBooking(Booking booking)
        {
            DataSetChange(booking, DB.DBOperation.Add);
            return UpdateDataSource(booking);
        }
        #endregion

        #region Helper Methods
        private void AddBookingsToCollection()
        {
            DataTable dataTable = DataSet.Tables[table];
            foreach (DataRow row in dataTable.Rows)
            {
                if (!int.TryParse(row["BookingID"]?.ToString(), out int bookingID))
                {
                    Console.WriteLine($"Invalid BookingID found: {row["BookingID"]}");
                    continue;
                }

                string custID = row["CustID"].ToString();
                string customerName = row["Name"].ToString();
                int? roomID = row["RoomID"] != DBNull.Value ? (int?)int.Parse(row["RoomID"].ToString()) : null;
                DateTime checkInDate = DateTime.Parse(row["CheckInDate"].ToString());
                DateTime checkOutDate = DateTime.Parse(row["CheckOutDate"].ToString());
                string status = row["Status"].ToString();
                string requestDetails = row["RequestDetails"]?.ToString();
                string numberOfGuests = row["NumberOfGuests"]?.ToString();

                Booking booking = new Booking(custID, checkInDate, checkOutDate, status, numberOfGuests, requestDetails)
                {
                    CustomerName = customerName
                };

                if (roomID.HasValue)
                {
                    booking.AssignRoom(roomID.Value);
                }

                booking.SetRequest(requestDetails);
                bookings.Add(booking);
            }
        }

        private DataRow FindRow(int bookingID)
        {
            DataTable dataTable = DataSet.Tables[table];
            DataRow[] rows = dataTable.Select($"BookingID = {bookingID}");
            return rows.Length > 0 ? rows[0] : null;
        }

        private void FillDataRow(DataRow row, Booking booking)
        {
            row["BookingID"] = booking.BookingID; // This will be auto-generated by the database
            row["CustID"] = booking.CustID;
            row["RoomID"] = booking.RoomID ?? (object)DBNull.Value;
            row["CheckInDate"] = booking.CheckInDate;
            row["CheckOutDate"] = booking.CheckOutDate;
            row["Status"] = booking.Status;
            row["RequestDetails"] = booking.RequestDetails ?? (object)DBNull.Value;
            row["NumberOfGuests"] = booking.NumberOfGuests ?? (object)DBNull.Value;
        }
        #endregion

        #region Update Command Logic
        protected override void FillDataSet(string sqlQuery, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataAdapter = new SqlDataAdapter(sqlQuery, connection);
                connection.Open();

                try
                {
                    DataAdapter.Fill(DataSet, tableName);

                    // Create Update and Insert Commands
                    CreateUpdateCommand((SqlDataAdapter)DataAdapter);
                    CreateInsertCommand((SqlDataAdapter)DataAdapter);
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
                    RequestDetails = @RequestDetails,
                    NumberOfGuests = @NumberOfGuests
                WHERE BookingID = @BookingID";

            adapter.UpdateCommand = new SqlCommand(updateSQL, SqlConnection);

            adapter.UpdateCommand.Parameters.Add("@CustID", SqlDbType.NVarChar, 50, "CustID");
            adapter.UpdateCommand.Parameters.Add("@RoomID", SqlDbType.Int, 0, "RoomID");
            adapter.UpdateCommand.Parameters.Add("@CheckInDate", SqlDbType.DateTime, 0, "CheckInDate");
            adapter.UpdateCommand.Parameters.Add("@CheckOutDate", SqlDbType.DateTime, 0, "CheckOutDate");
            adapter.UpdateCommand.Parameters.Add("@Status", SqlDbType.NVarChar, 50, "Status");
            adapter.UpdateCommand.Parameters.Add("@RequestDetails", SqlDbType.NVarChar, -1, "RequestDetails");
            adapter.UpdateCommand.Parameters.Add("@NumberOfGuests", SqlDbType.NVarChar, -1, "NumberOfGuests");
            adapter.UpdateCommand.Parameters.Add("@BookingID", SqlDbType.Int, 0, "BookingID");

            // Optimistic concurrency control
            adapter.UpdateCommand.Parameters.Add("@Original_BookingID", SqlDbType.Int, 0, "BookingID").SourceVersion = DataRowVersion.Original;
        }

        private void CreateInsertCommand(SqlDataAdapter adapter)
        {
            string insertSQL = @"
                INSERT INTO Booking (CustID, RoomID, CheckInDate, CheckOutDate, Status, RequestDetails, NumberOfGuests)
                VALUES (@CustID, @RoomID, @CheckInDate, @CheckOutDate, @Status, @RequestDetails, @NumberOfGuests);
                SELECT @BookingID = SCOPE_IDENTITY();";

            adapter.InsertCommand = new SqlCommand(insertSQL, SqlConnection);

            adapter.InsertCommand.Parameters.Add("@CustID", SqlDbType.NVarChar, 50, "CustID");
            adapter.InsertCommand.Parameters.Add("@RoomID", SqlDbType.Int, 0, "RoomID");
            adapter.InsertCommand.Parameters.Add("@CheckInDate", SqlDbType.DateTime, 0, "CheckInDate");
            adapter.InsertCommand.Parameters.Add("@CheckOutDate", SqlDbType.DateTime, 0, "CheckOutDate");
            adapter.InsertCommand.Parameters.Add("@Status", SqlDbType.NVarChar, 50, "Status");
            adapter.InsertCommand.Parameters.Add("@RequestDetails", SqlDbType.NVarChar, -1, "RequestDetails");
            adapter.InsertCommand.Parameters.Add("@NumberOfGuests", SqlDbType.NVarChar, -1, "NumberOfGuests");

            SqlParameter outputParam = adapter.InsertCommand.Parameters.Add("@BookingID", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output; // Set the output parameter for the BookingID
        }
        #endregion
    }
}
