using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
            AddCustomersToCollection();

            // Create commands for Insert, Update, and Delete
            CreateCommands();
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return DataSet;
        }

        private void AddCustomersToCollection()
        {
            foreach (DataRow myRow in DataSet.Tables[customerTable].Rows)
            {
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

        #region Create Commands for DataAdapter
        private void CreateCommands()
        {
            // Assuming SqlConnection is inherited from DB class
            SqlDataAdapter adapter = (SqlDataAdapter)DataAdapter;

            // InsertCommand
            string insertSQL = @"
                INSERT INTO Customer (CustID, Name, Surname, Phone, Email, Address, Status, Balance)
                VALUES (@CustID, @Name, @Surname, @Phone, @Email, @Address, @Status, @Balance)";
            adapter.InsertCommand = new SqlCommand(insertSQL, SqlConnection);
            AddCustomerParameters(adapter.InsertCommand);

            // UpdateCommand
            string updateSQL = @"
                UPDATE Customer 
                SET Name = @Name, Surname = @Surname, Phone = @Phone, 
                    Email = @Email, Address = @Address, Status = @Status, Balance = @Balance
                WHERE CustID = @CustID";
            adapter.UpdateCommand = new SqlCommand(updateSQL, SqlConnection);
            AddCustomerParameters(adapter.UpdateCommand);

            // DeleteCommand
            string deleteSQL = @"
                DELETE FROM Customer WHERE CustID = @CustID";
            adapter.DeleteCommand = new SqlCommand(deleteSQL, SqlConnection);
            adapter.DeleteCommand.Parameters.Add("@CustID", SqlDbType.Char, 13, "CustID");
        }

        private void AddCustomerParameters(SqlCommand command)
        {
            command.Parameters.Add("@CustID", SqlDbType.Char, 13, "CustID");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 100, "Name");
            command.Parameters.Add("@Surname", SqlDbType.NVarChar, 100, "Surname");
            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20, "Phone");
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 100, "Email");
            command.Parameters.Add("@Address", SqlDbType.Text, -1, "Address");
            command.Parameters.Add("@Status", SqlDbType.NVarChar, 20, "Status");
            command.Parameters.Add("@Balance", SqlDbType.Decimal).SourceColumn = "Balance";
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
                    if (customerRow != null)
                    {
                        FillRow(customerRow, customer, operation);
                    }
                    break;
                case DBOperation.Delete:
                    strIndex = customer.CustID;
                    customerRow = DataSet.Tables[customerTable].Rows.Find(strIndex);
                    if (customerRow != null)
                    {
                        customerRow.Delete();
                    }
                    break;
            }
        }

        public bool UpdateDataSource()
        {
            return UpdateDataSource(sqlLocalCustomer, customerTable);
        }
        #endregion
    }
}
