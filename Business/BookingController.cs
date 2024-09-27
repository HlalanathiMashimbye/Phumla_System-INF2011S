using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Phumla_System.Data;

namespace Phumla_System.Business
{
    public class BookingController
    {
        #region Data Members
        private BookingDB bookingDB;
        private Collection<Booking> bookings;
        #endregion

        #region Properties
        public Collection<Booking> AllBookings
        {
            get { return bookings; }
        }
        #endregion

        #region Constructor
        public BookingController()
        {
            bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Booking booking, DB.DBOperation operation)
        {
            int index = 0;
            bookingDB.DataSetChange(booking, operation);
            switch (operation)
            {
                case DB.DBOperation.Add:
                    bookings.Add(booking);
                    break;
                case DB.DBOperation.Change:
                    index = FindIndex(booking);
                    bookings[index] = booking;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(booking);
                    if (index >= 0)
                    {
                        bookings.RemoveAt(index);
                    }
                    break;
            }
        }

        public bool FinalizeChanges(Booking booking)
        {
            return bookingDB.UpdateDataSource(booking);
        }

        #endregion

        #region Search Methods
        private int FindIndex(Booking booking)
        {
            for (int i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].BookingID == booking.BookingID)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}