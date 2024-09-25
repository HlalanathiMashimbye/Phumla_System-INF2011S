using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Phumla_System.Data;

namespace Phumla_System.Business
{
    public class CustomerController
    {
        #region Data Members
        private BookingDB bookingDB;
        private Collection<Customer> customers;
        #endregion

        #region Properties
        public Collection<Customer> AllCustomers
        {
            get { return customers; }
        }
        #endregion

        #region Constructor
        public CustomerController()
        {
            bookingDB = new BookingDB();
            customers = bookingDB.AllCustomers;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Customer customer, DB.DBOperation operation)
        {
            int index = 0;
            bookingDB.DataSetChange(customer, operation);
            switch (operation)
            {
                case DB.DBOperation.Add:
                    customers.Add(customer);
                    break;
                case DB.DBOperation.Change:
                    index = FindIndex(customer);
                    customers[index] = customer;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(customer);
                    if (index >= 0)
                    {
                        customers.RemoveAt(index);
                    }
                    break;
            }
        }

        public bool FinalizeChanges(Customer customer)
        {
            return bookingDB.UpdateDataSource(sqlLocalCustomer, tableCustomer);
        }

        private int FindIndex(Customer customer)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].ID == customer.ID)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}
