using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phumla_System.Properties;
using Phumla_System.Business;

namespace Phumla_System.Data
{
    public class CustomerDB : DB
    {
        #region Data Members
        private string customerTable = "Customer";
        private string sqlLocalCustomer = "SELECT * FROM Customer";
        private Collection<Customer> customers;
        #endregion

        #region Property Methods: Collection
        public Collection<Customer> AllCustomers
        {
            get
            {
                return customers;
            }
        }
        #endregion

        #region Constructor
        public CustomerDB() : base()
        {
            customers = new Collection<Customer>();
            FillDataSet(sqlLocalCustomer, customerTable);
            AddCustomers2Collection(customerTable);
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return DataSet;
        }

        private void AddCustomers2Collection(string sqlTable)
        {
            DataRow myRow;
            foreach (DataRow myRow_loopVariable in DataSet.Tables[customerTable].Rows)
            {
                myRow = myRow_loopVariable;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    var aCustomer = new Customer(
                        Convert.ToString(myRow["CustID"]).TrimEnd(),
                        Convert.ToString(myRow["Name"]).TrimEnd(),
                        Convert.ToString(myRow["Surname"]).TrimEnd(),
                        Convert.ToString(myRow["Phone"]).TrimEnd(),
                        Convert.ToString(myRow["Email"]).TrimEnd(),
                        Convert.ToString(myRow["Address"]).TrimEnd(),
                        Convert.ToString(myRow["Status"]).TrimEnd(),
                        Convert.ToDecimal(myRow["Balance"])
                    );

                    customers.Add(aCustomer);
                }
            }
        }

        private void FillRow(DataRow aRow, Customer aCustomer, DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                aRow["CustID"] = aCustomer.CustID;
            }

            aRow["Name"] = aCustomer.Name;
            aRow["Surname"] = aCustomer.Surname;
            aRow["Phone"] = aCustomer.Phone;
            aRow["Email"] = aCustomer.Email;
            aRow["Address"] = aCustomer.Address;
            aRow["Status"] = aCustomer.Status;
            aRow["Balance"] = aCustomer.Balance;
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Customer customer, DBOperation operation)
        {
            DataRow customerRow = null;
            string strIndex;

            switch (operation)
            {
                case DBOperation.Add:
                    customerRow = DataSet.Tables[customerTable].NewRow();
                    FillRow(customerRow, customer, operation);
                    DataSet.Tables[customerTable].Rows.Add(customerRow);
                    break;
                case DBOperation.Change:
                    strIndex = customer.CustID;
                    customerRow = DataSet.Tables[customerTable].Rows.Find(strIndex);
                    FillRow(customerRow, customer, operation);
                    break;
                case DBOperation.Delete:
                    strIndex = customer.CustID;
                    customerRow = DataSet.Tables[customerTable].Rows.Find(strIndex);
                    customerRow.Delete();
                    break;
            }
        }

        public bool UpdateDataSource()
        {
            return UpdateDataSource(sqlLocalCustomer, customerTable);
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        // This region is empty in the original code
        #endregion
    }
}