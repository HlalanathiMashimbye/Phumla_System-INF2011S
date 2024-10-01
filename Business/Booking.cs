using System;

namespace Phumla_System.Business
{
    public class Booking
    {
        // Existing properties
        public int BookingID { get; }
        public string CustID { get; set; }
        public int? RoomID { get; set; }
        public string CustomerName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }
        public string RequestDetails { get; set; }
        public string NumberOfGuests { get; set; }

        // New property for room status
        public string RoomStatus { get; private set; }

        // Constructor (unchanged)
        public Booking( string custID, DateTime checkInDate, DateTime checkOutDate, string status, string numberOfGuests, string details)
        {
            CustID = custID;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = status;
            RequestDetails = details;
            NumberOfGuests = numberOfGuests;
        }

        // Existing methods (unchanged)
        public void AssignRoom(int roomID)
        {
            RoomID = roomID;
        }

        public void SetRequest(string requestDetails)
        {
            RequestDetails = requestDetails;
        }

        public void UpdateStatus(string newStatus)
        {
            if (newStatus == "Confirmed" || newStatus == "Cancelled" || newStatus == "Completed" || newStatus == "Changed" || newStatus == "Enquired")
            {
                Status = newStatus;
            }
            else
            {
                throw new ArgumentException("Invalid status value");
            }
        }

        public bool IsBookingValid()
        {
            return CheckOutDate > CheckInDate;
        }

        // New method to update room status
        public void UpdateRoomStatus(string newStatus)
        {
            if (newStatus == "Available" || newStatus == "Occupied" || newStatus == "Maintenance")
            {
                RoomStatus = newStatus;
            }
            else
            {
                throw new ArgumentException("Invalid room status value");
            }
        }

        // New method to get room status
        public string GetRoomStatus()
        {
            return RoomStatus;
        }
    }
}