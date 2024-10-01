using Phumla_System.Business;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Phumla_System.Data
{
    public class CustomerDB : DB
    {
        #region Data Members
        private Collection<Customer> customers;
        private string table = "Customer";
        private string sqlLocal = "SELECT * FROM Customer";
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
                    CreateUpdateCommand((SqlDataAdapter)DataAdapter);
                    CreateInsertCommand((SqlDataAdapter)DataAdapter);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error filling DataSet: " + ex.Message);
                }
            }
        }

        private void CreateUpdateCommand(SqlDataAdapter adapter)
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

            adapter.UpdateCommand = new SqlCommand(updateSQL, SqlConnection);

            adapter.UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 100, "Name");
            adapter.UpdateCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 100, "Surname");
            adapter.UpdateCommand.Parameters.Add("@Phone", SqlDbType.NVarChar, 20, "Phone");
            adapter.UpdateCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100, "Email");
            adapter.UpdateCommand.Parameters.Add("@Address", SqlDbType.Text, -1, "Address");
            adapter.UpdateCommand.Parameters.Add("@Status", SqlDbType.NVarChar, 20, "Status");
            adapter.UpdateCommand.Parameters.Add("@Balance", SqlDbType.Decimal, 0, "Balance");
            adapter.UpdateCommand.Parameters.Add("@CustID", SqlDbType.Char, 13, "CustID");

            // Optimistic concurrency control
            adapter.UpdateCommand.Parameters.Add("@Original_CustID", SqlDbType.Char, 13, "CustID").SourceVersion = DataRowVersion.Original;
        }

        private void CreateInsertCommand(SqlDataAdapter adapter)
        {
            string insertSQL = @"
                INSERT INTO Customer (CustID, Name, Surname, Phone, Email, Address, Status, Balance)
                VALUES (@CustID, @Name, @Surname, @Phone, @Email, @Address, @Status, @Balance)";

            adapter.InsertCommand = new SqlCommand(insertSQL, SqlConnection);

            adapter.InsertCommand.Parameters.Add("@CustID", SqlDbType.Char, 13, "CustID");
            adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 100, "Name");
            adapter.InsertCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 100, "Surname");
            adapter.InsertCommand.Parameters.Add("@Phone", SqlDbType.NVarChar, 20, "Phone");
            adapter.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100, "Email");
            adapter.InsertCommand.Parameters.Add("@Address", SqlDbType.Text, -1, "Address");
            adapter.InsertCommand.Parameters.Add("@Status", SqlDbType.NVarChar, 20, "Status");
            adapter.InsertCommand.Parameters.Add("@Balance", SqlDbType.Decimal, 0, "Balance");
        }
        #endregion
    }
}