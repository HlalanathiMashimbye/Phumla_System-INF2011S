using System;
using System.Collections.ObjectModel;
using System.Linq;
using Phumla_System.Data;
using static Phumla_System.Data.DB;

namespace Phumla_System.Business
{
    public class CustomerController
    {
        #region Data Members
        private CustomerDB customerDB;
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
            customerDB = new CustomerDB();
            customers = customerDB.AllCustomers;
        }
        #endregion

        #region Database Communication
        public bool FinalizeChanges(Customer customer)
        {
            // Ensure changes are committed to the database
            return customerDB.UpdateDataSource(customer);
        }

        public void DataMaintenance(Customer customer, DBOperation operation)
        {
            // Check for duplicate CustID when adding a new customer
            if (operation == DBOperation.Add && CustomerExists(customer.CustID))
            {
                throw new InvalidOperationException($"Customer with ID {customer.CustID} already exists.");
            }

            // Call DataSetChange to update the DataSet
            customerDB.DataSetChange(customer, operation);

            // Finalize changes to commit to the database
            if (FinalizeChanges(customer))
            {
                // Based on the operation, update the in-memory collection
                switch (operation)
                {
                    case DBOperation.Add:
                        customers.Add(customer); // Add to in-memory collection
                        break;
                    case DBOperation.Change:
                        int index = FindIndex(customer);
                        if (index >= 0)
                        {
                            customers[index] = customer; // Update in-memory collection
                        }
                        break;
                    case DBOperation.Delete:
                        int deleteIndex = FindIndex(customer);
                        if (deleteIndex >= 0)
                        {
                            customers.RemoveAt(deleteIndex); // Remove from in-memory collection
                        }
                        break;
                }
            }
            else
            {
                throw new InvalidOperationException("Failed to finalize changes to the database.");
            }
        }

        private int FindIndex(Customer customer)
        {
            // Find the index of a customer in the collection
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].CustID == customer.CustID)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool CustomerExists(string custID)
        {
            // Check if the customer exists in the collection
            return customers.Any(c => c.CustID == custID);
        }
        #endregion
    }
}
