using Phumla_System.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Phumla_System.Data
{
    public class RoomDB : DB
    {
        #region Data Members
        private string roomTable = "Room";
        private string sqlLocalRoom = "SELECT * FROM Room";
        private Collection<Room> rooms;
        #endregion

        #region Property Methods: Collection
        public Collection<Room> AllRooms
        {
            get
            {
                return rooms;
            }
        }
        #endregion

        #region Constructor
        public RoomDB() : base()
        {
            rooms = new Collection<Room>();
            FillDataSet(sqlLocalRoom, roomTable);
            AddRooms2Collection(roomTable);
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return DataSet;
        }

        private void AddRooms2Collection(string sqlTable)
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

        private void Add2Collection()
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

        private void FillRow(DataRow aRow, Room aRoom, DBOperation operation)
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
        #endregion

        #region Database Operations Crud
        #endregion

        #region Build Parameters, Create Commands & Update database
        #endregion
    }
}
