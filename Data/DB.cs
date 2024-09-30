using System;
using Phumla_System.Properties;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
                // Correctly initialize the SqlDataAdapter with the SQL query
                DataAdapter = new SqlDataAdapter(aSQLstring, SqlConnection);
                SqlConnection.Open();
                DataAdapter.Fill(DataSet, aTable);
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + " " + errObj.StackTrace);
            }
            finally
            {
                SqlConnection.Close(); // Ensure connection is closed in finally block
            }
        }

        #endregion

        #region Update the Data Source
        protected bool UpdateDataSource(string sqlLocal, string sqlTable)
        {
            bool success = false;
            try
            {
                SqlConnection.Open();
                DataAdapter.Update(DataSet, sqlTable);
                success = true;

                // Refresh the dataset after update
                FillDataSet(sqlLocal, sqlTable);
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + " " + errObj.StackTrace);
            }
            finally
            {
                SqlConnection.Close(); // Ensure connection is closed in finally block
            }
            return success;
        }
        #endregion
    }
}
