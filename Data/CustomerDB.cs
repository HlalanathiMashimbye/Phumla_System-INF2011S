using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Phumla_System.Business;

namespace Phumla_System.Data
{
    public class CustomerDB : DB
    {
        #region Data Members
        private Collection<Customer> customers;
        private string table = "Customer";
        private string sqlLocal = @"SELECT * FROM Customer";
        #endregion

        #region Constructor
        public CustomerDB() : base()
        {
            customers = new Collection<Customer>();
            FillDataSet(sqlLocal, table);
            AddCustomersToCollection();
        }
        #endregion

        #region Properties
        public Collection<Customer> AllCustomers
        {
            get { return customers; }
        }
        #endregion

        #region Database Operations
        public void DataSetChange(Customer customer, DB.DBOperation operation)
        {
            DataRow row = null;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    row = DataSet.Tables[table].NewRow();
                    FillDataRow(row, customer);
                    DataSet.Tables[table].Rows.Add(row);
                    break;
                case DB.DBOperation.Change:
                    row = FindRow(customer.CustID);
                    if (row != null)
                    {
                        FillDataRow(row, customer);
                    }
                    break;
                case DB.DBOperation.Delete:
                    row = FindRow(customer.CustID);
                    if (row != null)
                    {
                        row.Delete();
                    }
                    break;
            }
        }

        public bool UpdateDataSource(Customer customer)
        {
            if (DataAdapter == null)
            {
                FillDataSet(sqlLocal, table);
            }

            DataRow[] rows = DataSet.Tables[table].Select($"CustID = '{customer.CustID}'");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                FillDataRow(row, customer);
            }

            return base.UpdateDataSource(sqlLocal, table);
        }

        public bool InsertCustomer(Customer customer)
        {
            DataSetChange(customer, DB.DBOperation.Add);
            return UpdateDataSource(customer);
        }
        #endregion

        #region Helper Methods
        private void AddCustomersToCollection()
        {
            DataTable dataTable = DataSet.Tables[table];
            foreach (DataRow row in dataTable.Rows)
            {
                Customer customer = new Customer(
                    row["CustID"].ToString().TrimEnd(),
                    row["Name"].ToString().TrimEnd(),
                    row["Surname"].ToString().TrimEnd(),
                    row["Phone"].ToString().TrimEnd(),
                    row["Email"].ToString().TrimEnd(),
                    row["Address"].ToString().TrimEnd(),
                    row["Status"].ToString().TrimEnd(),
                    Convert.ToDecimal(row["Balance"])
                );

                customers.Add(customer);
            }
        }

        private DataRow FindRow(string custID)
        {
            DataTable dataTable = DataSet.Tables[table];
            DataRow[] rows = dataTable.Select($"CustID = '{custID}'");
            return rows.Length > 0 ? rows[0] : null;
        }

        private void FillDataRow(DataRow row, Customer customer)
        {
            row["CustID"] = customer.CustID;
            row["Name"] = customer.Name;
            row["Surname"] = customer.Surname;
            row["Phone"] = customer.Phone;
            row["Email"] = customer.Email;
            row["Address"] = customer.Address;
            row["Status"] = customer.Status;
            row["Balance"] = customer.Balance;
        }
        #endregion

        #region Update Command Logic
        protected override void FillDataSet(string sqlQuery, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataAdapter = new SqlDataAdapter(sqlQuery, connection);
                connection.Open();

                try
                {
                    DataAdapter.Fill(DataSet, tableName);

                    // Create Update and Insert Commands
                    CreateUpdateCommand();
                    CreateInsertCommand();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error filling DataSet: " + ex.Message);
                }
            }
        }

        private void CreateUpdateCommand()
        {
            string updateSQL = @"
                UPDATE Customer 
                SET Name = @Name, 
                    Surname = @Surname, 
                    Phone = @Phone, 
                    Email = @Email, 
                    Address = @Address, 
                    Status = @Status, 
                    Balance = @Balance
                WHERE CustID = @CustID";

            SqlCommand command = new SqlCommand(updateSQL, SqlConnection);

            command.Parameters.Add("@Name", SqlDbType.NVarChar, 100, "Name");
            command.Parameters.Add("@Surname", SqlDbType.NVarChar, 100, "Surname");
            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20, "Phone");
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 100, "Email");
            command.Parameters.Add("@Address", SqlDbType.Text, -1, "Address");
            command.Parameters.Add("@Status", SqlDbType.NVarChar, 20, "Status");
            command.Parameters.Add("@Balance", SqlDbType.Decimal, 0, "Balance");
            command.Parameters.Add("@CustID", SqlDbType.Char, 13, "CustID");

            ((SqlDataAdapter)DataAdapter).UpdateCommand = command;
        }

        private void CreateInsertCommand()
        {
            string insertSQL = @"
                INSERT INTO Customer (CustID, Name, Surname, Phone, Email, Address, Status, Balance)
                VALUES (@CustID, @Name, @Surname, @Phone, @Email, @Address, @Status, @Balance)";

            SqlCommand command = new SqlCommand(insertSQL, SqlConnection);

            command.Parameters.Add("@CustID", SqlDbType.Char, 13, "CustID");
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 100, "Name");
            command.Parameters.Add("@Surname", SqlDbType.NVarChar, 100, "Surname");
            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20, "Phone");
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 100, "Email");
            command.Parameters.Add("@Address", SqlDbType.Text, -1, "Address");
            command.Parameters.Add("@Status", SqlDbType.NVarChar, 20, "Status");
            command.Parameters.Add("@Balance", SqlDbType.Decimal, 0, "Balance");

            ((SqlDataAdapter)DataAdapter).InsertCommand = command;
        }
        #endregion
    }
}