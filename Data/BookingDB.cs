using Phumla_System.Properties;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_System.Data
{
    public class BookingDB
    {
        //enum to store operations
        public enum BookingDBoperatios
        {
            Add = 0,
            Change = 1,
            Delete = 2,
        }

        #region Variables
        private string strConn = Settings.Default.BookingsDatabaseConnectionString;
        protected SqlConnection SqlConnection;
        protected DataSet DataSet;
        protected SqlDataAdapter DataAdapter;
        #endregion

        #region Constructor
        public BookingDB() {
            try
            {
                SqlConnection = new SqlConnection(strConn);
                DataSet = new DataSet();
            }
            catch (SystemException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "ERROR");
                return;
               
            }
        
        
        }
        #endregion

        #region Populate the DataSet
        // Filling the Dataset with fresh table from a specific query
        protected void FillDataSet(string aSQLstring, string aTable)
        {
            try
            {
                DataAdapter = new SqlDataAdapter(aSQLstring, aTable);
                SqlConnection.Open();
                DataAdapter.Fill(DataSet, aTable);
                SqlConnection.Close();
            }
            catch (Exception errObj)
            {

                MessageBox.Show(errObj.Message + " " +  errObj.StackTrace);
            }
        }
        #endregion

        #region Update the Data Source
        protected bool UpdateDataSource(string sqlLocal, string sqlTable) {
            bool success;
            try
            {
                SqlConnection.Open();
                DataAdapter.Update(DataSet, sqlTable);
                SqlConnection.Close();
                FillDataSet(sqlLocal, sqlTable);
                success = true;
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + " " + errObj.StackTrace);
                success = false;
            }
            finally { }
            return success;
        }
        #endregion
    }
}
