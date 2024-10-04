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
        private SqlDataAdapter dataAdapter;
        private SqlCommandBuilder commandBuilder;
        #endregion

        #region Constructor
        public CustomerDB() : base()
        {
            customers = new Collection<Customer>();
            FillDataSet(sqlLocal, table);
            commandBuilder = new SqlCommandBuilder(dataAdapter);
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
                if (dataAdapter == null)
                {
                    FillDataSet(sqlLocal, table);
                }

                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    connection.Open();
                    dataAdapter.SelectCommand.Connection = connection;

                    // Find the row and update data
                    DataRow row = FindRow(customer.CustID);
                    if (row != null)
                    {
                        FillDataRow(row, customer);
                    }
                    else
                    {
                        row = DataSet.Tables[table].NewRow();
                        FillDataRow(row, customer);
                        DataSet.Tables[table].Rows.Add(row);
                    }

                    // Update the database
                    int rowsAffected = dataAdapter.Update(DataSet, table);
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
                dataAdapter = new SqlDataAdapter(sqlQuery, connection);
                try
                {
                    connection.Open();
                    dataAdapter.Fill(DataSet, tableName);

                    // Automatically generate commands for Insert, Update, Delete
                    commandBuilder = new SqlCommandBuilder(dataAdapter);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error filling DataSet: " + ex.Message, ex);
                }
            }
        }
        #endregion
    }
}
