using System;
using System.Collections.ObjectModel;
using System.Linq;
using Phumla_System.Data;

namespace Phumla_System.Business
{
    public class CustomerController
    {
        private CustomerDB customerDB;
        private Collection<Customer> customers;

        public Collection<Customer> AllCustomers
        {
            get { return customers; }
        }

        public CustomerController()
        {
            customerDB = new CustomerDB();
            customers = customerDB.AllCustomers;
        }

        public void DataMaintenance(Customer customer, DB.DBOperation operation)
        {
            switch (operation)
            {
                case DB.DBOperation.Add:
                    if (CustomerExists(customer.CustID))
                    {
                        throw new InvalidOperationException($"Customer with ID {customer.CustID} already exists.");
                    }
                    if (customerDB.InsertCustomer(customer))
                    {
                        customers.Add(customer);
                    }
                    else
                    {
                        throw new Exception("Failed to add customer to the database.");
                    }
                    break;

                case DB.DBOperation.Change:
                    if (FinalizeChanges(customer))
                    {
                        int changeIndex = FindIndex(customer);
                        if (changeIndex >= 0)
                        {
                            customers[changeIndex] = customer;
                        }
                    }
                    else
                    {
                        throw new Exception("Failed to update customer in the database.");
                    }
                    break;

                case DB.DBOperation.Delete:
                    int index = FindIndex(customer);
                    if (index >= 0)
                    {
                        customers.RemoveAt(index);
                        customerDB.DataSetChange(customer, DB.DBOperation.Delete);
                    }
                    break;
            }
        }

        public bool FinalizeChanges(Customer customer)
        {
            return customerDB.UpdateDataSource(customer);
        }

        private int FindIndex(Customer customer)
        {
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
            return customers.Any(c => c.CustID == custID);
        }

        // Additional methods can be added here as needed, similar to BookingController
        // For example:
        // public Customer GetCustomerById(string custID)
        // public Collection<Customer> SearchCustomers(string searchTerm)
        // etc.
    }
}