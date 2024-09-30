using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Phumla_System.Properties;

namespace Phumla_System.Data
{
    public class DB
    {
        // Enum to store operations
        public enum DBOperation
        {
            Add = 0,
            Change = 1,
            Delete = 2,
        }

        #region Variables
        public string strConn = Settings.Default.BookingsDatabaseConnectionString;
        protected SqlConnection SqlConnection;
        protected DataSet DataSet;
        protected SqlDataAdapter DataAdapter;
        #endregion

        #region Constructor
        public DB()
        {
            try
            {
                SqlConnection = new SqlConnection(strConn);
                DataSet = new DataSet();
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }
        #endregion

        #region Populate the DataSet
        // Filling the Dataset with fresh table from a specific query
        protected virtual void FillDataSet(string aSQLstring, string aTable)
        {
            try
            {
                DataAdapter = new SqlDataAdapter(aSQLstring, SqlConnection);

                // Check if connection is already open
                if (SqlConnection.State != ConnectionState.Open)
                {
                    SqlConnection.Open();
                }

                DataAdapter.Fill(DataSet, aTable);
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + " " + errObj.StackTrace);
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
        }
        #endregion

        #region Update the Data Source
        protected bool UpdateDataSource(string sqlLocal, string sqlTable)
        {
            bool success = false;
            try
            {
                if (DataAdapter == null)
                {
                    throw new InvalidOperationException("DataAdapter is not initialized.");
                }

                if (((SqlDataAdapter)DataAdapter).UpdateCommand == null)
                {
                    throw new InvalidOperationException("UpdateCommand is not set for the DataAdapter.");
                }

                // Ensure the connection string is set
                if (string.IsNullOrEmpty(SqlConnection.ConnectionString))
                {
                    SqlConnection.ConnectionString = strConn;
                }

                // Ensure the UpdateCommand has a valid connection
                if (((SqlDataAdapter)DataAdapter).UpdateCommand.Connection == null ||
                    string.IsNullOrEmpty(((SqlDataAdapter)DataAdapter).UpdateCommand.Connection.ConnectionString))
                {
                    ((SqlDataAdapter)DataAdapter).UpdateCommand.Connection = SqlConnection;
                }

                SqlConnection.Open();
                int rowsAffected = DataAdapter.Update(DataSet, sqlTable);
                success = rowsAffected > 0;

                // Refresh the dataset after update
                FillDataSet(sqlLocal, sqlTable);
            }
            catch (Exception errObj)
            {
                MessageBox.Show($"Error updating data source: {errObj.Message}\n\nStack Trace: {errObj.StackTrace}");
            }
            finally
            {
                SqlConnection.Close();
            }
            return success;
        }
        #endregion
    }
}