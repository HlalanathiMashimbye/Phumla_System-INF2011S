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
        public void DataMaintenance(Customer customer, DBOperation operation)
        {
            int index = 0;
            customerDB.DataSetChange(customer, operation);
            switch (operation)
            {
                case DBOperation.Add:
                    customers.Add(customer);
                    break;
                case DBOperation.Change:
                    index = FindIndex(customer);
                    if (index >= 0)
                    {
                        customers[index] = customer;
                    }
                    break;
                case DBOperation.Delete:
                    index = FindIndex(customer);
                    if (index >= 0)
                    {
                        customers.RemoveAt(index);
                    }
                    break;
            }
        }

        public bool FinalizeChanges()
        {
            return customerDB.UpdateDataSource();
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

        #endregion
    }
}
