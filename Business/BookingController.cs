using System;
using System.Collections.ObjectModel;
using System.Linq;
using Phumla_System.Data;

namespace Phumla_System.Business
{
    public class BookingController
    {
        private BookingDB bookingDB;
        private RoomDB roomDB;
        private Collection<Booking> bookings;

        public Collection<Booking> AllBookings
        {
            get { return bookings; }
        }

        public BookingController()
        {
            bookingDB = new BookingDB();
            roomDB = new RoomDB();
            bookings = bookingDB.AllBookings;
        }

        public void DataMaintenance(Booking booking, DB.DBOperation operation)
        {
            bookingDB.DataSetChange(booking, operation);
            switch (operation)
            {
                case DB.DBOperation.Add:
                    bookings.Add(booking);
                    break;
                case DB.DBOperation.Change:
                    int index = FindIndex(booking);
                    if (index >= 0)
                    {
                        bookings[index] = booking;
                    }
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

        // New method to check if a customer has a booking
        public bool CustomerHasBooking(string custID)
        {
            return bookings.Any(b => b.CustID == custID);
        }

        // New method to update room status
        public void UpdateRoomStatus(int roomID, string newStatus)
        {
            var room = roomDB.AllRooms.FirstOrDefault(r => r.RoomID == roomID);
            if (room != null)
            {
                room.Status = newStatus;
                roomDB.DataSetChange(room, DB.DBOperation.Change);
                roomDB.UpdateDataSource();
            }
            else
            {
                throw new ArgumentException("Room not found");
            }
        }

        // New method to get room status
        public string GetRoomStatus(int roomID)
        {
            var room = roomDB.AllRooms.FirstOrDefault(r => r.RoomID == roomID);
            return room?.Status ?? throw new ArgumentException("Room not found");
        }

        // New method to get all available rooms
        public Collection<Room> GetAvailableRooms()
        {
            return new Collection<Room>(roomDB.AllRooms.Where(r => r.Status == "Available").ToList());
        }

        // New method to assign a room to a booking
        public void AssignRoomToBooking(int bookingID, int roomID)
        {
            var booking = bookings.FirstOrDefault(b => b.BookingID == bookingID);
            var room = roomDB.AllRooms.FirstOrDefault(r => r.RoomID == roomID);

            if (booking != null && room != null && room.Status == "Available")
            {
                booking.AssignRoom(roomID);
                room.Status = "Occupied";
                DataMaintenance(booking, DB.DBOperation.Change);
                roomDB.DataSetChange(room, DB.DBOperation.Change);
                FinalizeChanges(booking);
                roomDB.UpdateDataSource();
            }
            else
            {
                throw new ArgumentException("Invalid booking or room, or room is not available");
            }
        }

        // Method to get bookings for a specific room
        public Collection<Booking> GetBookingsForRoom(int roomID)
        {
            return bookingDB.GetBookingsForRoom(roomID);
        }

        // Method to check if rooms are available for a given date range
        public Collection<Room> GetAvailableRoomsForDateRange(DateTime checkIn, DateTime checkOut)
        {
            var availableRooms = roomDB.AllRooms.Where(r => r.Status == "Available").ToList();

            // Filter rooms that are available for the specified date range
            var bookedRoomsDuringDateRange = bookings
                .Where(b => b.CheckInDate < checkOut && b.CheckOutDate > checkIn)
                .Select(b => b.RoomID)
                .Distinct()
                .ToList();

            return new Collection<Room>(availableRooms
                .Where(r => !bookedRoomsDuringDateRange.Contains(r.RoomID))
                .ToList());
        }

        // Method to randomly assign an available room or waitlist (assign Room 0)
        public int AssignRoomBasedOnAvailability(DateTime checkInDate, DateTime checkOutDate)
        {
            var availableRooms = GetAvailableRoomsForDateRange(checkInDate, checkOutDate);

            if (availableRooms.Count == 0)
            {
                // No rooms available, return Room 0 for waitlist
                return 0;
            }
            else
            {
                // Randomly assign one of the available rooms
                Random rand = new Random();
                int randomIndex = rand.Next(availableRooms.Count);
                return availableRooms[randomIndex].RoomID;
            }
        }
    }
}
