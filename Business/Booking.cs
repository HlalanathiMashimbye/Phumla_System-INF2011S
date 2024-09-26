using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_System.Business
{
    public class Booking
    {
        // Properties for the Booking class
        #region Property Methods
        public string BookingID { get; set; }
        public string CustID { get; set; }
        public string RoomID { get; set; } // Nullable
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; } // 'Confirmed', 'Cancelled', 'Completed'
        public string RequestType { get; set; } // RequestType as per your updated design
        public string RequestDetails { get; set; } // Details of the request
        public DateTime RequestDate { get; set; } // Date of the request
        #endregion

        // Constructor for creating a Booking
        #region Constructor
        public Booking(string bookingID, string custID, DateTime checkInDate, DateTime checkOutDate, string status)
        {
            BookingID = bookingID;
            CustID = custID;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = status;
            RequestType = null;
            RequestDetails = null;
            RequestDate = DateTime.MinValue;
        }
        #endregion

        // Method to update the room allocation (optional for your system)
        public void AssignRoom(string roomID)
        {
            RoomID = roomID;
        }

        // Method to set request details
        public void SetRequest(string requestType, string requestDetails, DateTime requestDate)
        {
            RequestType = requestType;
            RequestDetails = requestDetails;
            RequestDate = requestDate;
        }

        // Method to change booking status
        public void UpdateStatus(string newStatus)
        {
            if (newStatus == "Confirmed" || newStatus == "Cancelled" || newStatus == "Completed")
            {
                Status = newStatus;
            }
            else
            {
                throw new ArgumentException("Invalid status value");
            }
        }

        // Method to check if the booking is valid (e.g., Check-out must be after Check-in)
        public bool IsBookingValid()
        {
            return CheckOutDate > CheckInDate;
        }
    }
}
