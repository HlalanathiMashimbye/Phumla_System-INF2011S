using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Phumla_System.Data;

namespace Phumla_System.Business
{
    public class RoomController
    {
        #region Data Members
        private BookingDB bookingDB;
        private Collection<Room> rooms;
        #endregion

        #region Properties
        public Collection<Room> AllRooms
        {
            get { return rooms; }
        }
        #endregion

        #region Constructor
        public RoomController()
        {
            bookingDB = new BookingDB();
            rooms = bookingDB.AllRooms;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Room room, DB.DBOperation operation)
        {
            int index = 0;
            bookingDB.DataSetChange(room, operation);
            switch (operation)
            {
                case DB.DBOperation.Add:
                    rooms.Add(room);
                    break;
                case DB.DBOperation.Change:
                    index = FindIndex(room);
                    rooms[index] = room;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(room);
                    if (index >= 0)
                    {
                        rooms.RemoveAt(index);
                    }
                    break;
            }
        }

        public bool FinalizeChanges(Room room)
        {
            return bookingDB.UpdateDataSource(sqlLocalRoom, tableRoom);
        }

        private int FindIndex(Room room)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].ID == room.ID)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}
