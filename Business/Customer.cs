using System;

namespace Phumla_System.Business
{
    public class Customer
    {
        #region Properties for the Customer class
        public string CustID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Balance { get; set; } // Default: 0
        public string Status { get; set; } // 'Active', 'Inactive', 'Blacklisted'
        #endregion

        #region Constructor to create a Customer
        public Customer(string custID, string name, string surname, string phone, string email, string address, string status = "Active", decimal balance = 0)
        {
            CustID = custID;
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
            Address = address;
            Status = status;
            Balance = balance;
        }
        #endregion

        #region Update contact information
        public void UpdateContactInfo(string phone, string email, string address)
        {
            Phone = phone;
            Email = email;
            Address = address;
        }
        #endregion

        #region Update status
        public void UpdateStatus(string newStatus)
        {
            if (newStatus == "Active" || newStatus == "Inactive" || newStatus == "Blacklisted")
            {
                Status = newStatus;
            }
            else
            {
                throw new ArgumentException("Invalid status value");
            }
        }
        #endregion

        #region Add balance amount
        public void AddBalance(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative");
            }
            Balance += amount;
        }
        #endregion

        #region Subtract balance amount
        public void DeductBalance(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient balance");
            }
            Balance -= amount;
        }
        #endregion
    }
}
