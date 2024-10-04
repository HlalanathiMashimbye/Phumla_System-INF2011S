using Phumla_System.Business;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

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
            bool success = false;
            try
            {
                if (DataAdapter == null)
                {
                    FillDataSet(sqlLocal, table);
                }

                SqlDataAdapter sqlDataAdapter = (SqlDataAdapter)DataAdapter;

                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    connection.Open();

                    // Ensure InsertCommand and UpdateCommand have connections
                    if (sqlDataAdapter.InsertCommand == null)
                    {
                        CreateInsertCommand(sqlDataAdapter);
                    }
                    sqlDataAdapter.InsertCommand.Connection = connection;

                    if (sqlDataAdapter.UpdateCommand == null)
                    {
                        CreateUpdateCommand(sqlDataAdapter);
                    }
                    sqlDataAdapter.UpdateCommand.Connection = connection;

                    // Find the row and update data
                    DataRow row = FindRow(customer.CustID);
                    if (row != null)
                    {
                        // If the row is unchanged, update it
                        if (row.RowState == DataRowState.Unchanged || row.RowState == DataRowState.Modified)
                        {
                            FillDataRow(row, customer);
                        }
                        else if (row.RowState == DataRowState.Added)
                        {
                            // Row was added, no need to set modified, just ensure it's ready for insert
                            FillDataRow(row, customer);
                        }
                    }
                    else
                    {
                        // If the row does not exist, add it as a new row
                        row = DataSet.Tables[table].NewRow();
                        FillDataRow(row, customer);
                        DataSet.Tables[table].Rows.Add(row);
                    }

                    // Update database
                    int rowsAffected = sqlDataAdapter.Update(DataSet, table);
                    success = rowsAffected > 0;
                }

                // Accept changes to DataSet
                DataSet.AcceptChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating data source: " + ex.Message, ex);
            }

            return success;
        }

        #endregion

        #region Helper Methods
        private void AddCustomersToCollection()
        {
            DataTable dataTable = DataSet.Tables[table];
            foreach (DataRow row in dataTable.Rows)
            {
                Customer customer = new Customer(
                    row["custID"].ToString().TrimEnd(),
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
            DataRow[] rows = dataTable.Select($"custID = '{custID}'");
            return rows.Length > 0 ? rows[0] : null;
        }

        private void FillDataRow(DataRow row, Customer customer)
        {
            row["custID"] = customer.CustID;
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
                SqlDataAdapter sqlDataAdapter = (SqlDataAdapter)DataAdapter;

                try
                {
                    connection.Open();
                    sqlDataAdapter.Fill(DataSet, tableName);

                    // Create Update and Insert Commands
                    CreateUpdateCommand(sqlDataAdapter);
                    CreateInsertCommand(sqlDataAdapter);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error filling DataSet: " + ex.Message, ex);
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
                WHERE custID = @custID";

            adapter.UpdateCommand = new SqlCommand(updateSQL);

            adapter.UpdateCommand.Parameters.Add("@Name", SqlDbType.VarChar, 100, "Name");
            adapter.UpdateCommand.Parameters.Add("@Surname", SqlDbType.VarChar, 100, "Surname");
            adapter.UpdateCommand.Parameters.Add("@Phone", SqlDbType.VarChar, 20, "Phone");
            adapter.UpdateCommand.Parameters.Add("@Email", SqlDbType.VarChar, 100, "Email");
            adapter.UpdateCommand.Parameters.Add("@Address", SqlDbType.Text, -1, "Address");
            adapter.UpdateCommand.Parameters.Add("@Status", SqlDbType.VarChar, 20, "Status");
            adapter.UpdateCommand.Parameters.Add("@Balance", SqlDbType.Decimal, 0, "Balance");
            adapter.UpdateCommand.Parameters.Add("@custID", SqlDbType.Char, 13, "custID");

            // Optimistic concurrency control
            adapter.UpdateCommand.Parameters.Add("@Original_custID", SqlDbType.Char, 13, "custID").SourceVersion = DataRowVersion.Original;
        }

        private void CreateInsertCommand(SqlDataAdapter adapter)
        {
            string insertSQL = @"
                INSERT INTO Customer (custID, Name, Surname, Phone, Email, Address, Status, Balance)
                VALUES (@custID, @Name, @Surname, @Phone, @Email, @Address, @Status, @Balance)";

            adapter.InsertCommand = new SqlCommand(insertSQL);

            adapter.InsertCommand.Parameters.Add("@custID", SqlDbType.Char, 13, "custID");
            adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.VarChar, 100, "Name");
            adapter.InsertCommand.Parameters.Add("@Surname", SqlDbType.VarChar, 100, "Surname");
            adapter.InsertCommand.Parameters.Add("@Phone", SqlDbType.VarChar, 20, "Phone");
            adapter.InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar, 100, "Email");
            adapter.InsertCommand.Parameters.Add("@Address", SqlDbType.Text, -1, "Address");
            adapter.InsertCommand.Parameters.Add("@Status", SqlDbType.VarChar, 20, "Status");
            adapter.InsertCommand.Parameters.Add("@Balance", SqlDbType.Decimal, 0, "Balance");
        }
        #endregion
    }
}
