using Phumla_System.Business;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

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
                        Convert.ToInt32(myRow["RoomID"]),
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

        #region Database Operations CRUD
        public void DataSetChange(Room room, DBOperation operation)
        {
            DataRow roomRow = null;
            int strIndex;

            switch (operation)
            {
                case DBOperation.Add:
                    roomRow = DataSet.Tables[roomTable].NewRow();
                    FillRow(roomRow, room, operation);
                    DataSet.Tables[roomTable].Rows.Add(roomRow);
                    break;
                case DBOperation.Change:
                    strIndex = room.RoomID;
                    roomRow = DataSet.Tables[roomTable].Rows.Find(strIndex);
                    FillRow(roomRow, room, operation);
                    break;
                case DBOperation.Delete:
                    strIndex = room.RoomID;
                    roomRow = DataSet.Tables[roomTable].Rows.Find(strIndex);
                    roomRow.Delete();
                    break;
            }
        }

        public bool UpdateDataSource()
        {
            return UpdateDataSource(sqlLocalRoom, roomTable);
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        // This region is empty in the original code
        #endregion
    }
}
