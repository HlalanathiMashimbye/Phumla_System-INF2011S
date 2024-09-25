using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_System.Data
{
    internal class BookingDB
    {
=======
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Phumla_System.Properties;

namespace Phumla_System.Data
{
    public class BookingDB : DB
    {
        #region Data members        
        private string tableRoom = "Room";
        private string sqlLocalRoom = "SELECT * FROM Room";
        private string tableCustomer = "Customer";
        private string sqlLocalCustomer = "SELECT * FROM Customer";
        private string tableBooking = "Booking";
        private string sqlLocalBooking = "SELECT * FROM Booking";
        private Collection<Room> rooms;
        private Collection<Customer> customers;
        private Collection<Booking> bookings;

        #endregion

        #region Property Methods: Collections
        public Collection<Room> AllRooms
        {
            get
            {
                return rooms;
            }
        }

        public Collection<Customer> AllCustomers
        {
            get
            {
                return customers;
            }
        }

        public Collection<Booking> AllBookings
        {
            get
            {
                return bookings;
            }
        }
        #endregion

        #region Constructor
        public BookingDB() : base()
        {
            rooms = new Collection<Room>();
            customers = new Collection<Customer>();
            bookings = new Collection<Booking>();
            FillDataSet(sqlLocalRoom, tableRoom);
            AddToCollection(tableRoom);
            FillDataSet(sqlLocalCustomer, tableCustomer);
            AddToCollection(tableCustomer);
            FillDataSet(sqlLocalBooking, tableBooking);
            AddToCollection(tableBooking);
        }
        #endregion

        #region Utility Methods
        private void AddToCollection(string table)
        {
            DataRow myRow = null;

            switch (table)
            {
                case "Room":
                    foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
                    {
                        myRow = myRow_loopVariable;
                        if (!(myRow.RowState == DataRowState.Deleted))
                        {
                            Room room = new Room
                            {
                                ID = Convert.ToString(myRow["ID"]).TrimEnd(),
                                RoomNumber = Convert.ToString(myRow["RoomNumber"]).TrimEnd(),
                                RoomType = Convert.ToString(myRow["RoomType"]).TrimEnd(),
                                Price = Convert.ToDecimal(myRow["Price"])
                            };
                            rooms.Add(room);
                        }
                    }
                    break;

                case "Customer":
                    foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
                    {
                        myRow = myRow_loopVariable;
                        if (!(myRow.RowState == DataRowState.Deleted))
                        {
                            Customer customer = new Customer
                            {
                                ID = Convert.ToString(myRow["ID"]).TrimEnd(),
                                Name = Convert.ToString(myRow["Name"]).TrimEnd(),
                                ContactNumber = Convert.ToString(myRow["ContactNumber"]).TrimEnd()
                            };
                            customers.Add(customer);
                        }
                    }
                    break;

                case "Booking":
                    foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
                    {
                        myRow = myRow_loopVariable;
                        if (!(myRow.RowState == DataRowState.Deleted))
                        {
                            Booking booking = new Booking
                            {
                                ID = Convert.ToString(myRow["ID"]).TrimEnd(),
                                CustomerID = Convert.ToString(myRow["CustomerID"]).TrimEnd(),
                                RoomID = Convert.ToString(myRow["RoomID"]).TrimEnd(),
                                CheckInDate = Convert.ToDateTime(myRow["CheckInDate"]),
                                CheckOutDate = Convert.ToDateTime(myRow["CheckOutDate"])
                            };
                            bookings.Add(booking);
                        }
                    }
                    break;
            }
        }

        private void FillRow(DataRow aRow, object obj, DB.DBOperation operation)
        {
            if (obj is Room room)
            {
                if (operation == DB.DBOperation.Add)
                {
                    aRow["ID"] = room.ID;
                }
                aRow["RoomNumber"] = room.RoomNumber;
                aRow["RoomType"] = room.RoomType;
                aRow["Price"] = room.Price;
            }
            else if (obj is Customer customer)
            {
                if (operation == DB.DBOperation.Add)
                {
                    aRow["ID"] = customer.ID;
                }
                aRow["Name"] = customer.Name;
                aRow["ContactNumber"] = customer.ContactNumber;
            }
            else if (obj is Booking booking)
            {
                if (operation == DB.DBOperation.Add)
                {
                    aRow["ID"] = booking.ID;
                }
                aRow["CustomerID"] = booking.CustomerID;
                aRow["RoomID"] = booking.RoomID;
                aRow["CheckInDate"] = booking.CheckInDate;
                aRow["CheckOutDate"] = booking.CheckOutDate;
            }
        }

        private int FindRow(object obj, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;

            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    if (obj is Room room && room.ID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
                    {
                        returnValue = rowIndex;
                        break;
                    }
                    else if (obj is Customer customer && customer.ID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
                    {
                        returnValue = rowIndex;
                        break;
                    }
                    else if (obj is Booking booking && booking.ID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ID"]))
                    {
                        returnValue = rowIndex;
                        break;
                    }
                }
                rowIndex++;
            }
            return returnValue;
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(object obj, DB.DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = "";

            if (obj is Room)
            {
                dataTable = tableRoom;
            }
            else if (obj is Customer)
            {
                dataTable = tableCustomer;
            }
            else if (obj is Booking)
            {
                dataTable = tableBooking;
            }

            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, obj, operation);
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;

                case DB.DBOperation.Change:
                    aRow = dsMain.Tables[dataTable].Rows[FindRow(obj, dataTable)];
                    FillRow(aRow, obj, operation);
                    break;

                case DB.DBOperation.Delete:
                    int rowIndex = FindRow(obj, dataTable);
                    if (rowIndex >= 0)
                    {
                        dsMain.Tables[dataTable].Rows.RemoveAt(rowIndex);
                    }
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        // Similar to the EmployeeDB, build insert, update, and delete methods for Room, Customer, and Booking
        // Create_INSERT_Command, Build_INSERT_Parameters, Create_UPDATE_Command, Build_UPDATE_Parameters, etc.

        // Implement these methods based on the specific structure of your Room, Customer, and Booking classes
        #endregion
>>>>>>> Stashed changes
    }
}
