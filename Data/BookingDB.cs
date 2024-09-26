using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using Phumla_System.Properties;
using Phumla_System.Business;

namespace Phumla_System.Data
{
    public class BookingDB : DB
    {
        #region Data members
        private string bookingTable = "Booking";
        private string roomTable = "Room";
        private string customerTable = "Customer";
        private string sqlLocalBooking = "SELECT * FROM Booking";
        private string sqlLocalRoom = "SELECT * FROM Room";
        private string sqlLocalCustomer = "SELECT * FROM Customer";
        private Collection<Booking> bookings;
        private Collection<Room> rooms;
        private Collection<Customer> customers;
        #endregion

        #region Property Methods: Collections
        public Collection<Booking> AllBookings => bookings;

        public Collection<Room> AllRooms => rooms;

        public Collection<Customer> AllCustomers => customers;
        #endregion

        #region Constructor
        public BookingDB() : base()
        {
            bookings = new Collection<Booking>();
            rooms = new Collection<Room>();
            customers = new Collection<Customer>();

            FillDataSet(sqlLocalBooking, bookingTable);
            FillDataSet(sqlLocalRoom, roomTable);
            FillDataSet(sqlLocalCustomer, customerTable);

            AddBookings2Collection();
            AddRooms2Collection();
            AddCustomers2Collection();
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return DataSet;
        }

        private void AddBookings2Collection()
        {
            DataRow myRow;
            foreach (DataRow myRow_loopVariable in DataSet.Tables[bookingTable].Rows)
            {
                myRow = myRow_loopVariable;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    var aBooking = new Booking(
                        Convert.ToString(myRow["BookingID"]).TrimEnd(),
                        Convert.ToString(myRow["CustID"]).TrimEnd(),
                        Convert.ToDateTime(myRow["CheckInDate"]),
                        Convert.ToDateTime(myRow["CheckOutDate"]),
                        Convert.ToString(myRow["Status"]).TrimEnd()
                    )
                    {
                        RoomID = Convert.ToString(myRow["RoomID"]).TrimEnd(),
                        RequestType = Convert.ToString(myRow["RequestType"]).TrimEnd(),
                        RequestDetails = Convert.ToString(myRow["RequestDetails"]).TrimEnd(),
                        RequestDate = Convert.ToDateTime(myRow["RequestDate"])
                    };

                    bookings.Add(aBooking);
                }
            }
        }

        private void AddRooms2Collection()
        {
            DataRow myRow;
            foreach (DataRow myRow_loopVariable in DataSet.Tables[roomTable].Rows)
            {
                myRow = myRow_loopVariable;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    var aRoom = new Room(
                        Convert.ToString(myRow["RoomID"]).TrimEnd(),
                        Convert.ToString(myRow["HotelID"]).TrimEnd(),
                        Convert.ToString(myRow["Status"]).TrimEnd(),
                        Convert.ToString(myRow["Number"]).TrimEnd(),
                        Convert.ToString(myRow["Type"]).TrimEnd(),
                        Convert.ToDecimal(myRow["Rate"])
                    );

                    rooms.Add(aRoom);
                }
            }
        }

        private void AddCustomers2Collection()
        {
            DataRow myRow;
            foreach (DataRow myRow_loopVariable in DataSet.Tables[customerTable].Rows)
            {
                myRow = myRow_loopVariable;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    var aCustomer = new Customer(
                        Convert.ToString(myRow["CustID"]).TrimEnd(),
                        Convert.ToString(myRow["Name"]).TrimEnd(),
                        Convert.ToString(myRow["Surname"]).TrimEnd(),
                        Convert.ToString(myRow["Phone"]).TrimEnd(),
                        Convert.ToString(myRow["Email"]).TrimEnd(),
                        Convert.ToString(myRow["Address"]).TrimEnd(),
                        Convert.ToString(myRow["Status"]).TrimEnd(),
                        Convert.ToDecimal(myRow["Balance"])
                    );

                    customers.Add(aCustomer);
                }
            }
        }

        private void FillBookingRow(DataRow aRow, Booking aBooking, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["BookingID"] = aBooking.BookingID;
                aRow["CustID"] = aBooking.CustID;
            }

            aRow["RoomID"] = aBooking.RoomID;
            aRow["CheckInDate"] = aBooking.CheckInDate;
            aRow["CheckOutDate"] = aBooking.CheckOutDate;
            aRow["Status"] = aBooking.Status;
            aRow["RequestType"] = aBooking.RequestType;
            aRow["RequestDetails"] = aBooking.RequestDetails;
            aRow["RequestDate"] = aBooking.RequestDate;
        }

        private void FillRoomRow(DataRow aRow, Room aRoom, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["RoomID"] = aRoom.RoomID;
                aRow["HotelID"] = aRoom.HotelID;
            }

            aRow["Status"] = aRoom.Status;
            aRow["Number"] = aRoom.Number;
            aRow["Type"] = aRoom.Type;
            aRow["Rate"] = aRoom.Rate;
        }

        private void FillCustomerRow(DataRow aRow, Customer aCustomer, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["CustID"] = aCustomer.CustID;
            }

            aRow["Name"] = aCustomer.Name;
            aRow["Surname"] = aCustomer.Surname;
            aRow["Phone"] = aCustomer.Phone;
            aRow["Email"] = aCustomer.Email;
            aRow["Address"] = aCustomer.Address;
            aRow["Status"] = aCustomer.Status;
            aRow["Balance"] = aCustomer.Balance;
        }

        private int FindRow(string id, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            string idColumn = table + "ID";

            foreach (DataRow myRow_loopVariable in DataSet.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    if (id == Convert.ToString(DataSet.Tables[table].Rows[rowIndex][idColumn]))
                    {
                        returnValue = rowIndex;
                    }
                }
                rowIndex++;
            }
            return returnValue;
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(object entity, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = "";

            if (entity is Booking booking)
            {
                dataTable = bookingTable;
                switch (operation)
                {
                    case DBOperation.Add:
                        aRow = DataSet.Tables[dataTable].NewRow();
                        FillBookingRow(aRow, booking, operation);
                        DataSet.Tables[dataTable].Rows.Add(aRow);
                        break;
                    case DBOperation.Change:
                        aRow = DataSet.Tables[dataTable].Rows[FindRow(booking.BookingID, dataTable)];
                        FillBookingRow(aRow, booking, operation);
                        break;
                    case DBOperation.Delete:
                        int rowIndex = FindRow(booking.BookingID, dataTable);
                        if (rowIndex >= 0)
                        {
                            DataSet.Tables[dataTable].Rows.RemoveAt(rowIndex);
                        }
                        break;
                }
            }
            else if (entity is Room room)
            {
                dataTable = roomTable;
                switch (operation)
                {
                    case DBOperation.Add:
                        aRow = DataSet.Tables[dataTable].NewRow();
                        FillRoomRow(aRow, room, operation);
                        DataSet.Tables[dataTable].Rows.Add(aRow);
                        break;
                    case DBOperation.Change:
                        aRow = DataSet.Tables[dataTable].Rows[FindRow(room.RoomID, dataTable)];
                        FillRoomRow(aRow, room, operation);
                        break;
                    case DBOperation.Delete:
                        int rowIndex = FindRow(room.RoomID, dataTable);
                        if (rowIndex >= 0)
                        {
                            DataSet.Tables[dataTable].Rows.RemoveAt(rowIndex);
                        }
                        break;
                }
            }
            else if (entity is Customer customer)
            {
                dataTable = customerTable;
                switch (operation)
                {
                    case DBOperation.Add:
                        aRow = DataSet.Tables[dataTable].NewRow();
                        FillCustomerRow(aRow, customer, operation);
                        DataSet.Tables[dataTable].Rows.Add(aRow);
                        break;
                    case DBOperation.Change:
                        aRow = DataSet.Tables[dataTable].Rows[FindRow(customer.CustID, dataTable)];
                        FillCustomerRow(aRow, customer, operation);
                        break;
                    case DBOperation.Delete:
                        int rowIndex = FindRow(customer.CustID, dataTable);
                        if (rowIndex >= 0)
                        {
                            DataSet.Tables[dataTable].Rows.RemoveAt(rowIndex);
                        }
                        break;
                }
            }
        }

        
        #endregion

        #region Database Commit
        public void CommitDataSet()
        {
            SqlDataAdapter adapter;
            SqlCommandBuilder commandBuilder;

            adapter = new SqlDataAdapter("SELECT * FROM " + bookingTable, SqlConnection);
            commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(DataSet, bookingTable);

            adapter = new SqlDataAdapter("SELECT * FROM " + roomTable, SqlConnection);
            commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(DataSet, roomTable);

            adapter = new SqlDataAdapter("SELECT * FROM " + customerTable, SqlConnection);
            commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(DataSet, customerTable);
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters(Booking aBook)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            DataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@BookingID", SqlDbType.NVarChar, 10, "BookingID");
            DataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
            DataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.NVarChar, 15, "Phone");
            DataAdapter.InsertCommand.Parameters.Add(param);

            param = new SqlParameter(

        }

        private void Build_UPDATE_Parameters(Booking aBook)
        { }

        private void Create_UPDATE_Command(Booking aBook)
        { }

        private void Create_INSERT_Command(Booking Book)
        { }

        public bool UpdateDataSource(Booking aBook)
        { }

        #endregion
    }
}
