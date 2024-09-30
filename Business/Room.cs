using System;

namespace Phumla_System.Business
{
    public class Room
    {
        #region Fields
        public int RoomID { get; set; }
        public string HotelID { get; set; }
        public string Status { get; set; } // 'Available', 'Occupied', 'Maintenance'
        public string Number { get; set; }
        public string Type { get; set; }
        public decimal Rate { get; set; } // Room rate per night
        #endregion

        #region Constructor
        public Room(int roomID, string hotelID, string status, string number, string type, decimal rate)
        {
            RoomID = roomID;
            HotelID = hotelID;
            Status = status;
            Number = number;
            Type = type;
            Rate = rate;
        }
        #endregion

        #region Update room status
        public void UpdateStatus(string newStatus)
        {
            if (newStatus == "Available" || newStatus == "Occupied" || newStatus == "Maintenance")
            {
                Status = newStatus;
            }
            else
            {
                throw new ArgumentException("Invalid status value");
            }
        }
        #endregion

        #region Update room rate
        public void UpdateRate(decimal newRate)
        {
            if (newRate >= 0)
            {
                Rate = newRate;
            }
            else
            {
                throw new ArgumentException("Rate cannot be negative");
            }
        }
        #endregion

        #region Availability
        public bool IsAvailable()
        {
            return Status == "Available";
        }
        #endregion
    }
}
